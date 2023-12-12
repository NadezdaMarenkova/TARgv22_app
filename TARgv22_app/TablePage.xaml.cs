using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView tableView;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection fotosection;
        public TablePage()
        {
            fotosection= new TableSection
            { 
              //LayoutAlignment.Center
            };
            switchCell= new SwitchCell 
            { 
                Text = "Näita veel ..."
            };
            switchCell.OnChanged += SwitchCell_OnChanged;

            imageCell= new ImageCell 
            { 
                Text = "Foto: ",
                ImageSource = "bees.png", 
                Detail = "Foto kirjeldus"
            };
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmed: ")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        new EntryCell
                        {
                            Label = "Nimi: ",
                            Placeholder = "Siia tuleb nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed: ")
                    {
                        new EntryCell
                        {
                            Label = "Telefon: ",
                            Placeholder = "Kirjuta telefoni nr.",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email: ",
                            Placeholder = "Siia tuleb email",
                            Keyboard = Keyboard.Email

                        },
                        switchCell 
                    },
                    fotosection
                }
            };
            Content = tableView;
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto: ";
                fotosection.Add(imageCell);
                switchCell.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(imageCell);
                switchCell.Text = "Näita veel";
            }
        }
    }
}