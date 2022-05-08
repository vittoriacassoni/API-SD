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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map_Front
{
    public partial class frUser : Form
    {
        bool _create = true;
        int id = 0;

        public event EventHandler<bool> ReloadUsers;

        public frUser(bool create = true, string idToSearch = "", int nextId = 0)
        {
            InitializeComponent();

            if (create)
            {
                lkDelete.Visible = false;
            }
            else
            {
                _create = false;
                lkDelete.Visible = true;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Const_API.URL_API);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.Http.HttpResponseMessage response = client.GetAsync("api/user/GetUserById/" + idToSearch).Result;
                if (response.IsSuccessStatusCode)
                {
                    UserVO user = JsonConvert.DeserializeObject<UserVO>(response.Content.ReadAsStringAsync().Result);
                    id = Convert.ToInt16(idToSearch);

                    txtName.Text = user.Name;
                    txtEmail.Text = user.Email;
                    txtCountry.Text = user.Country;
                    txtState.Text = user.State;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_create)
            {
                UserVO user = new UserVO();
                user.Id = id;
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Country = txtCountry.Text;
                user.State = txtState.Text;

                var stringContent = JsonConvert.SerializeObject(user);
                var data = new StringContent(stringContent, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Const_API.URL_API);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.Http.HttpResponseMessage response = client.PostAsync("api/user/CreateUser", data).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri usuarioUri = response.Headers.Location;

                    MessageBox.Show(response.Content.ReadAsStringAsync().Result.ToString());

                    ReloadUsers?.Invoke(this, true);
                }
            }
            else
            {
                UserVO user = new UserVO();
                user.Id = id;
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Country = txtCountry.Text;
                user.State = txtState.Text;

                var stringContent = JsonConvert.SerializeObject(user);
                var data = new StringContent(stringContent, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Const_API.URL_API);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.Http.HttpResponseMessage response = client.PutAsync("api/user/EditUser", data).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri usuarioUri = response.Headers.Location;

                    MessageBox.Show(response.Content.ReadAsStringAsync().Result.ToString());

                    ReloadUsers?.Invoke(this, true);
                }
            }
        }

        private void lkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Const_API.URL_API);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client.DeleteAsync("api/user/DeleteUser/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Uri usuarioUri = response.Headers.Location;

                MessageBox.Show(response.Content.ReadAsStringAsync().Result.ToString());

                ReloadUsers?.Invoke(this, true);

                this.Close();
            }
        }
    }
}
