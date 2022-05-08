using Map_API.Models;
using Map_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Map_API.Controllers
{
    [RoutePrefix("api/parter_institutions")]
    public class PartnerInstitutionsController : ApiController
    {
        private static List<PartnerInstitutionsViewModel> partnerInstitutionsList = new List<PartnerInstitutionsViewModel>();

        /// <summary>
        /// Metodo responsavel por cadastrar uma instituição parceira
        /// </summary>
        /// <param name="partnerInstitution">Insituição parceira a ser incluida</param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("CreatePartnerInstitution")]
        public string CreatePartnerInstitution(PartnerInstitutionsViewModel partnerInstitution)
        {
            try
            {
                partnerInstitutionsList.Add(partnerInstitution);
                return "Instituição parceira cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao cadastrar a Instituição parceira ";
            }
        }

        /// <summary>
        /// Metodo responsavel por modificar uma Instituição parceira, sendo o Id o mandatório para achar o registro 
        /// </summary>
        /// <param name="partnerInstitution">Instituição parceira com as modificações</param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("EditPartnerInstitution")]
        public string EditPartnerInstitution(PartnerInstitutionsViewModel partnerInstitution)
        {
            try
            {
                PartnerInstitutionsViewModel partnetInstitutionToEdit = partnerInstitutionsList.Where(u => u.Id == partnerInstitution.Id).FirstOrDefault();

                if (partnetInstitutionToEdit != null)
                {
                    partnetInstitutionToEdit.Address = partnerInstitution.Address;
                    partnetInstitutionToEdit.Phone = partnerInstitution.Phone;
                    partnetInstitutionToEdit.Name = partnerInstitution.Name;
                }
                else
                {
                    return "Instituição parceira não encontrada!";
                }

                return "Instituição parceira alterada com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao editar a Instituição parceira";
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar uma Instituição parceira  de acordo com o id 
        /// </summary>
        /// <param name="id">Id da Instituição parceira que será deletado</param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("DeletePartnerInstitution/{id}")]
        public string DeleteUser(int id)
        {
            try
            {
                PartnerInstitutionsViewModel partnerInstitution = partnerInstitutionsList.FirstOrDefault(n => n.Id == id);

                if (partnerInstitution != null)
                    return "Instituição parceira inexistente!";

                partnerInstitutionsList.Remove(partnerInstitution);

                return "Instituição parceira excluida com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao excluir a Instituição parceira";
            }
        }


        /// <summary>
        /// Metodo responsavel por buscar Instituições parceiras de acordo com o email
        /// </summary>
        /// <param name="email">Id da Instituição parceira que deseja buscar</param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("GetPartnerInstitutionById/{id}")]
        public PartnerInstitutionsViewModel GetPartnerInstitutionById(int id)
        {
            try
            {
                PartnerInstitutionsViewModel parterInstitution = partnerInstitutionsList.FirstOrDefault(n => n.Id == id);

                return parterInstitution;
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por listar todos as Instituições parceiras
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("ListPartnerInstitutions")]
        public List<PartnerInstitutionsViewModel> ListPartnerInstitutions()
        {
            try
            {
                return partnerInstitutionsList;

            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por popular as Instituições parceiras
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("LoadPartnerInstitutions")]
        public string LoadPartnerInstitutions()
        {
            try
            {
                partnerInstitutionsList.Clear();
                partnerInstitutionsList.Add(new PartnerInstitutionsViewModel(1, "Casa da Mulher Brasileira", "Rua Viêira Ravasco 26 (Cambuci), São Paulo, SP", "(11) 9999-9999", System.DateTime.Now));
                partnerInstitutionsList.Add(new PartnerInstitutionsViewModel(2, "O INSTITUTO MARIA DA PENHA", "Rua Pedro Epichin 29 (To), Colatina, ES", "(27) 9090-8989", System.DateTime.Now));

                return "Instituições parceiras carregadas com sucesso";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao carregar as Instituições parceiras!";
            }

        }
    }
}
