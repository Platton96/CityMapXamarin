using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Core.ViewModels;
using CityMapXamarin.Droid.Converters;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Login page", MainLauncher = true, Theme = "@style/Theme.Login")]
    public class LoginView : MvxAppCompatActivity<LoginViewModel>
    {
        private EditText _email;
        private EditText _password;
        private AppCompatButton _loginBtn;
        private TextView _errorMessage;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginPage);
            InitComponents();
            ApplyBindings();
        }

        private void InitComponents()
        {
            _email = FindViewById<EditText>(Resource.Id.input_email);
            _password= FindViewById<EditText>(Resource.Id.input_password);
            _loginBtn = FindViewById<AppCompatButton>(Resource.Id.btn_login);
            _errorMessage = FindViewById<TextView>(Resource.Id.text_view_error_message);
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<LoginView, LoginViewModel>();
            bindingSet.Bind(_email).For(b => b.Text).To(vm => vm.Email);
            bindingSet.Bind(_password).For(b => b.Text).To(vm => vm.Password);
            bindingSet.Bind(_errorMessage).For(b => b.Visibility).To(vm => vm.IsVisibleErrorMessage).WithConversion<BoolToViewStatecsConverter>();
            bindingSet.Bind(_loginBtn).To(vm => vm.LoginAsyncCommand);
            bindingSet.Apply();
        }
    }
}