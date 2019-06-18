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
            string consulta =   "SELECT[puerto_nombre] FROM[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Puerto]"
                                +" inner join("
                                +" select[recorrido_puerto_destino] from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido]"
                                +" where recorrido_codigo in ("
                                +"        SELECT[recorrido_codigo] from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido]"
                                +"        WHERE recorrido_puerto_inicio = 27 and recorrido_anterior is null)"  //este 27 seria una ID hardcodeada del puerto origen, del que actualmente solo tengo el nombre
		                        +"        ) as hola"
                                +" on id_puerto = hola.recorrido_puerto_destino";

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
