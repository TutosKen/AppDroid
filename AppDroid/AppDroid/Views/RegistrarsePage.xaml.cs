﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDroid.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarsePage : ContentPage
    {
        RegistrarseViewModel vm;

        public RegistrarsePage()
        {
            InitializeComponent();
            BindingContext = vm = new RegistrarseViewModel();
        }
        private bool verificarContrasenna()
        {
            if (TxtPass.Text.Trim() == TxtConfirmPass.Text.Trim())
            {
                return true;
            }
            return false;
        }

        private async void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            if (Txtemail.Text.Trim() != "" && TxtNombre.Text.Trim() != "" && TxtPass.Text.Trim() != "" && TxtConfirmPass.Text.Trim() != "")
            {
                if (verificarContrasenna())
                {
                    if (await vm.VerificarEmail(Txtemail.Text.Trim()))
                    {
                        await DisplayAlert("Error", "El correo ya se encuentra en uso", "OK");
                    }
                    else
                    {
                        bool R = await vm.AgregarUsuario(TxtNombre.Text.Trim(), Txtemail.Text.Trim(), TxtPass.Text.Trim(), 1);

                        if (R)
                        {
                            await DisplayAlert("Aviso", "Usuario registrado correctamente", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Error al agregar usuario", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Debe llenar todos los campos", "OK");
            }
           
        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SwVerPass_T(object sender, ToggledEventArgs e)
        {
            TxtPass.IsPassword = true;
            TxtConfirmPass.IsPassword = true;

            if (SwVerPass.IsToggled)
            {
                TxtPass.IsPassword = false;
                TxtConfirmPass.IsPassword = false;
            }
        }
    }
}