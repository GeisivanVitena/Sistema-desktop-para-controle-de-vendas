using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeVendasApp.br.com.project.Model
{
    public class Helpers
    {
        public void LimparTela(Form tela)
        {
            foreach (Control ctrPai in tela.Controls)
            {
                foreach (Control ctr1 in ctrPai.Controls)
                {
                    if (ctr1 is TabPage)
                    {
                        foreach  (Control ctr2 in ctr1.Controls)
                        {
                            if (ctr2 is GroupBox)
                            {
                                foreach (Control ctr3  in ctr2.Controls)
                                {
                                    if (ctr3 is TextBox)
                                    {
                                        (ctr3 as TextBox).Text = string.Empty;
                                    }

                                    if (ctr3 is MaskedTextBox)
                                    {
                                        (ctr3 as MaskedTextBox).Text = string.Empty;
                                    }

                                    if (ctr3 is ComboBox)
                                    {
                                        (ctr3 as ComboBox).Text = string.Empty;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
