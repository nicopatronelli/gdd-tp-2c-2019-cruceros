using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class CompraReservaForm : Form
    {
        List<string> origenes;
        List<string> destinos;
        public CompraReservaForm()
        {
            InitializeComponent();


        }

        private void CompraReservaForm_Load(object sender, EventArgs e)
        {

            string consulta = "SELECT[puerto_nombre] from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]";
;

            Query miConsulta = new Query(consulta,new List<Parametro>());
            this.origenes = miConsulta.ejecutarReaderUnicaColumna();
            foreach(var o in origenes)
            {
                this.origenesList.Items.Add(o);
            }

        }

        /*
"SELECT[puerto_nombre] from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]"
                                + "WHERE[id_puerto] in (SELECT[recorrido_puerto_inicio] FROM[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido]"
                                +  "WHERE recorrido_anterior is NULL)"
*/

        private void FiltroOrigen_TextChanged(object sender, EventArgs e)
        {
            origenesList.Items.Clear();
            this.cargarLista(origenesList, origenes.Where(o => o.Contains(filtroOrigen.Text.ToUpper())).ToList());
            //origenes.Where(o => o.Contains(filtroOrigen.Text.ToUpper()))
        }

        private void cargarLista( ListBox result, List<string> input) {
            foreach (var item in input)
            {
                result.Items.Add(item);
            }
                //System.Windows.Forms.ListBox.ObjectCollection
        }

        private void OrigenesList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.destinosList.Items.Clear();
            this.buscarDestinos( (string) origenesList.SelectedItem);
            
        }

        private void buscarDestinos(string origen)
        {
            string consulta = ""
                               + " select puerto_nombre from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]"
                               + " where id_puerto in("
                               + "         select t.tramo_puerto_destino from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr"
                               + "         where txr.id_recorrido in ("
                               + "             select r.[id_recorrido] from  [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t"
                               + "             where txr.tramo_anterior is NULL and  txr.id_tramo = t.id_tramo AND txr.id_recorrido = r.id_recorrido AND t.tramo_puerto_inicio = 10"
                               + "             )"
                               + "         AND txr.id_tramo = t.id_tramo"
                               + "         )";

            Query miConsulta = new Query(consulta, new List<Parametro>());
            this.destinos = miConsulta.ejecutarReaderUnicaColumna();
            
            foreach (var o in destinos)
            {
                this.destinosList.Items.Add(o);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            if(calendario.SelectionStart == calendario.SelectionEnd)
            {
                errorMsg += "Selecciona una fecha\n";
            }
            if(calendario.SelectionStart <= DateTime.Today)
            {
                errorMsg += "Seleccione una fecha posterior a la actual\n";
            }
            if (this.origenesList.SelectedItem == null)
            {
                errorMsg += "Seleccione un puerto de origen\n";
            }
            if (this.destinosList.SelectedItem == null)
            {
                errorMsg += "Seleccione un puerto de destino\n";
            }
            if (errorMsg != "")
            {
                resultLabel.Text = errorMsg;
                return;
            }
            resultLabel.Text = "Buena fecha";
            ElegirViajeForm elegirViajeForm = new ElegirViajeForm((string)this.origenesList.SelectedItem, (string)this.destinosList.SelectedItem, calendario.SelectionStart);
            elegirViajeForm.ShowDialog();
        }

        //aca esta la consulta de arriba. EN SQL me devuelve 2 valores, pero aca me da null
        /*
SELECT  [puerto_nombre] FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]
inner join (
select [recorrido_puerto_destino] from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido]
where recorrido_codigo in(
		SELECT [recorrido_codigo]from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido]
		WHERE recorrido_puerto_inicio = 27 and recorrido_anterior is null)
		) as hola
on id_puerto = hola.recorrido_puerto_destino
*/

    }
}




/*
--recorridos en los que el puerto inicial es de id 10
select r.[id_recorrido] from  [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t
where txr.tramo_anterior is NULL and  txr.id_tramo = t.id_tramo AND txr.id_recorrido = r.id_recorrido AND t.tramo_puerto_inicio = 10
--devuelve id 19


--dado un recorrido, buscar los posibles destinos. ej Recorrido 19
select t.tramo_puerto_destino from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr
where txr.id_recorrido in (19) AND txr.id_tramo = t.id_tramo
--devuelve puertos 6 y 44


---union de las 2 anteriores
select t.tramo_puerto_destino from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr
where txr.id_recorrido in (
	select r.[id_recorrido] from  [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t
	where txr.tramo_anterior is NULL and  txr.id_tramo = t.id_tramo AND txr.id_recorrido = r.id_recorrido AND t.tramo_puerto_inicio = 10
	)
AND txr.id_tramo = t.id_tramo

--agrego que me devuelva el nombre de los puertos
select puerto_nombre from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]
where id_puerto in(
		select t.tramo_puerto_destino from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr
		where txr.id_recorrido = (
			select r.[id_recorrido] from  [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr, [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t
			where txr.tramo_anterior is NULL and  txr.id_tramo = t.id_tramo AND txr.id_recorrido = r.id_recorrido AND t.tramo_puerto_inicio = 10
			)
		AND txr.id_tramo = t.id_tramo
		)

*/