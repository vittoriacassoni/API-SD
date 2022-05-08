using Map_Front.Comuns;
using Map_Front.VOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map_Front
{
    public partial class frMain : Form
    {
        public List<UserVO> users = null;
        public List<ReportVO> reports = null;
        public List<PartnerInstitutionsVO> partners = null;

        public frMain()
        {
            InitializeComponent();

            LoadUsers();
            LoadReports();
            LoadPartnersInstitutions();
        }

        #region METODOS DE CARREGAMENTO DA BASE
        private void LoadPartnersInstitutions()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/parter_institutions/LoadPartnerInstitutions").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                var responseString = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        private void LoadReports()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/report/LoadReports").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                var responseString = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        private static void LoadUsers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/user/LoadUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                var responseString = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        #endregion

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            frUser formUser = new frUser(nextId: users.Max(t => t.Id) + 1);
            formUser.Show();
            formUser.ReloadUsers += frUser_ReloadUsers;
        }

        public void frUser_ReloadUsers(object sender, bool IsSuccessful)
        {
            ListUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            frUser formUser = new frUser(false, txtEmail.Text);
            formUser.Show();
        }

        private void btnListUser_Click(object sender, EventArgs e)
        {
            txtList.Clear();

            ListUsers();
        }

        private void ListUsers()
        {
            txtList.Clear();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/user/ListUsers").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                users = JsonConvert.DeserializeObject<List<UserVO>>(response.Content.ReadAsStringAsync().Result);
                foreach (UserVO userText in users)
                {
                    txtList.Text += $"Usuário Código: { userText.Id.ToString()} - Nome: {userText.Name} - Email: {userText.Email} - Local: {userText.State}, {userText.Country}";
                    txtList.Text += Environment.NewLine;
                }
            }
        }

        private void btnListPartners_Click(object sender, EventArgs e)
        {
            txtList.Clear();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/parter_institutions/ListPartnerInstitutions").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                partners = JsonConvert.DeserializeObject<List<PartnerInstitutionsVO>>(response.Content.ReadAsStringAsync().Result);
                foreach (PartnerInstitutionsVO partnerText in partners)
                {
                    txtList.Text += $"Instituição Parceira Código: { partnerText.Id.ToString()} - Nome: {partnerText.Name} - Endereço: {partnerText.Address} - Telefone: {partnerText.Phone}";
                    txtList.Text += Environment.NewLine;
                }
            }
        }

        private void btnListReport_Click(object sender, EventArgs e)
        {
            txtList.Clear();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/report/ListReports").Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                reports = JsonConvert.DeserializeObject<List<ReportVO>>(response.Content.ReadAsStringAsync().Result);
                foreach (ReportVO reportText in reports)
                {
                    txtList.Text += $"Reporte Código: { reportText.Id.ToString()} - Tipo: {reportText.Type} - Descrição: {reportText.Description} - Endereço: {reportText.Address} - Id do usuário: {reportText.UserId}";
                    txtList.Text += Environment.NewLine;
                }
            }
        }
    }
}
