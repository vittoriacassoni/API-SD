using Map_API.Models;
using Map_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Map_API.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        private static List<ReportViewModel> reportList = new List<ReportViewModel>();

        /// <summary>
        /// Metodo responsavel por cadastrar um novo reporte
        /// </summary>
        /// <param name="report">Reporte a ser incluido</param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("CreateReport")]
        public string CreateReport(ReportViewModel report)
        {
            try
            {
                reportList.Add(report);
                return "Reporte cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao cadastrar o reporte";
            }
        }

        /// <summary>
        /// Metodo responsavel por deletar um reporte de acordo com o id 
        /// </summary>
        /// <param name="id">Id do reporte que será deletado</param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("DeleteReport/{id}")]
        public string DeleteReport(int id)
        {
            try
            {
                ReportViewModel report = reportList.FirstOrDefault(n => n.Id == id);

                if (report != null)
                    return "Reporte inexistente!";

                reportList.Remove(report);

                return "Reporte excluido com sucesso!";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao excluir o reporte";
            }
        }


        /// <summary>
        /// Metodo responsavel por buscar reportes de acordo com o usuario
        /// </summary>
        /// <param name="type">Tipo do reporte</param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("GetReportByUserId/{userId}")]
        public ReportViewModel GetReportByUserId(int userId)
        {
            try
            {
                ReportViewModel report = reportList.FirstOrDefault(n => n.UserId == userId);

                return report;
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por listar todos os reportes
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("ListReports")]
        public List<ReportViewModel> ListReports()
        {
            try
            {
                return reportList;

            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Metodo responsavel por popular os reportes iniciais 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("LoadReports")]
        public string LoadReports()
        {
            try
            {
                reportList.Clear();
                reportList.Add(new ReportViewModel(1, "Rua Marina 1121, Santo André, SP, 09070-510", "Assédio Sexual", "Sofri um assédio sexual por volta das 18h por um homem que aparentava ter 38 anos", 4, System.DateTime.Now));
                reportList.Add(new ReportViewModel(2, "Rua Alegre 744, São Caetano do Sul, SP, 09550-250", "Assédio Sexual", "Um homem tentou passar a mão em mim no ponto de ônibus.", 4, System.DateTime.Now));
                reportList.Add(new ReportViewModel(3, "Avenida Lauro Gomes 1701 (Vila Vivaldi), São Bernardo do Campo, SP, 09617", "Assédio Verbal", "Homens que estavam em um bar gritaram palavras de baixo calão enquanto passava na rua", 2, System.DateTime.Now));
                reportList.Add(new ReportViewModel(4, "Rua Visconde de Inhauma 590, São Caetano do Sul, SP, 09571-000", "Assédio Sexual", "Sofri um assédio sexual por volta das 12h por um homem que aparentava ter 56 anos na fila do banco", 3, System.DateTime.Now));
              
                return "Reportes carregados com sucesso";
            }
            catch (Exception ex)
            {
                Logger.GenerateLog(ex);
                return "Ocorreu um erro ao carregar os resportes!";
            }

        }
    }
}