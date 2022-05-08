using Map_API.Models;
using Map_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Map_API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private static List<UserViewModel> userList = new List<UserViewModel>();

        /// <summary>
        /// Metodo responsavel por cadastrar um novo usuário
        /// </summary>
        /// <param name="user">Usuário a ser incluido</param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("CreateUser")]
        public string CreateUser(UserViewModel user)
        {
            try
            {
                userList.Add(user);
                return "Usuário cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao cadastrar o usuário";
            }
        }

        /// <summary>
        /// Metodo responsavel por modificar um usario, sendo o Id o mandatório para achar o registro do usuário
        /// </summary>
        /// <param name="user">usuario com as modificações</param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("EditUser")]
        public string EditUser(UserViewModel user)
        {
            try
            {
                UserViewModel userToEdit = userList.Where(u => u.Id == user.Id).FirstOrDefault();

                if (userToEdit != null)
                {
                    userToEdit.State = user.State;
                    userToEdit.Email = user.Email;
                    userToEdit.Name = user.Name;
                    userToEdit.Country = user.Country;
                }
                else
                {
                    return "Usuário não encontrado!";
                }

                return "Usuário alterado com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao editar o usuário";
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um usuário de acordo com o id 
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("DeleteUser/{id}")]
        public string DeleteUser(int id)
        {
            try
            {
                UserViewModel user = userList.FirstOrDefault(n => n.Id == id);

                if (user == null)
                    return "Usuário inexistente!";

                userList.Remove(user);

                return "Usuário excluido com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao excluir o usuário";
            }
        }


        /// <summary>
        /// Metodo responsavel por buscar usuários de acordo com o email
        /// </summary>
        /// <param name="email">eEmail do usuário que deseja buscar</param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("GetUserById/{id}")]
        public UserViewModel GetUserById(int id)
        {
            try
            {
                UserViewModel user = userList.FirstOrDefault(n => n.Id == id);

                return user;
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por listar todos os usuarios
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("ListUsers")]
        public List<UserViewModel> ListUsers()
        {
            try
            {
                return userList;

            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por popular os usuários 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("LoadUsers")]
        public string LoadUsers()
        {
            try
            {
                userList.Clear();
                userList.Add(new UserViewModel(1, "Bruna Cristina Torres", "bruna@email.com", "Brasil", "São Paulo", System.DateTime.Now));
                userList.Add(new UserViewModel(2, "Laura Alves Ferreira", "laura@email.com", "Brasil", "São Paulo", System.DateTime.Now));
                userList.Add(new UserViewModel(3, "Mariana Carnevale de Lima", "mariana@email.com", "Brasil", "São Paulo", System.DateTime.Now));
                userList.Add(new UserViewModel(4, "Vittoria Cassoni", "vittoria@email.com", "Brasil", "São Paulo", System.DateTime.Now));

                return "Usuários carregados com sucesso";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao carregar os usuários!";
            }

        }
    }
}