﻿using Aesoftware.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aesoftware.Manager
{
    public class FormManager
    {
        private static FormManager instance = null;
        private static readonly object padlock = new object();
        private bool isInit = false;

        public List<Form> formList = new List<Form>();
        private Form defaultForm = new Form();
        public LoginForm loginForm = new LoginForm();
        private RegisterForm registerForm = new RegisterForm();
        private MainMenuForm mainMenuForm = new MainMenuForm();

        FormManager()
        {
        }
        public static FormManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new FormManager();
                    }
                }

                return instance;
            }
        }

        public Form Init()
        {
            if (isInit)
                return null;

            defaultForm = loginForm;

            formList.Clear();
            formList.Add(loginForm);
            formList.Add(registerForm);
            formList.Add(mainMenuForm);

            isInit = true;

            return defaultForm;
        }

        public void ShowForm(string formName)
        {
            Form newForm = formList.Where(form => form.Name == formName).FirstOrDefault();

            if (newForm != null)
                newForm.Show();
        }
        public void CloseAllForm(string exceptionForm = "")
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != exceptionForm)
                    form.Hide();
                else
                    form.Show();
            }
        }

        public void ChangeForm(string formName)
        {
            Form newForm = formList.Where(form => form.Name == formName).FirstOrDefault();

            if (newForm != null)
            {
                newForm.Show();
                CloseAllForm(newForm.Name);
            }
        }

        public void ShowMessageBox(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        public DialogResult ShowMesageBoxButton(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon = 0)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        public void Login(string username, string password)
        {
            if (AccountManager.Instance.Login(username, password))
            {
                ShowMesageBoxButton("login success", "user authenticated!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeForm("MainMenuForm");
            }
            else
                ShowMesageBoxButton("login failed", "failed to authenticate user", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Logout()
        {
            ChangeForm("LoginForm");
        }

        public void ResetInputBoxLoginForm()
        {
            loginForm.LoginInputBox.Text = "";
            loginForm.PasswordInputBox.Text = "";
        }
    }
}