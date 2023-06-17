using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp
{
    public class WhatsApp
    {
        public string BusinessId => "";

        public static string IdNumeroTelefone => "";

        public static string TokenAcessoUsuario => "";

        public static string Link => "https://graph.facebook.com";

        public static string TemplateMesagemTexto => "";

        public static string TemplateMensagemLink => "";

        public static string TemplateMensagemPdf => "";

        public static string Versao => "v17.0";

        /// <summary>
        /// Tipo do cabeçalho da template
        /// </summary>
        public enum eTipoCabecalho
        {
            Nenhum,
            Texto,
            Imagem,
            Video,
            Documento,
            Localizacao
        }

        /// <summary>
        /// Retorna uma instância do objeto RestClient, usado para fazer solicitações HTTP.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static RestClient GetClient()
        {
            if (string.IsNullOrEmpty(Link))
            {
                throw new Exception("Link não foi informado nas configurações do WhatsApp");
            }

            var options = new RestClientOptions(Link)
            {
                MaxTimeout = -1
            };
            var client = new RestClient(options);

            return client;
        }

        /// <summary>
        /// Retorna uma instância do objeto RestRequest com configurações específicas para fazer uma solicitação HTTP POST.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static RestRequest GetRequisicao()
        {
            var pendencias = new List<string>();

            if (string.IsNullOrEmpty(Versao))
            {
                pendencias.Add("Versao");
            }
            if (string.IsNullOrEmpty(IdNumeroTelefone))
            {
                pendencias.Add("IdNumeroTelefone");
            }
            if (string.IsNullOrEmpty(TokenAcessoUsuario))
            {
                pendencias.Add("TokenAcessoUsuario");
            }

            if (pendencias.Count > 0)
            {
                var msgErro = string.Join(", ", pendencias);
                throw new Exception($"{msgErro}, não foi informado nas configurações do WhatsApp.");
            }

            var request = new RestRequest($"/{Versao}/{IdNumeroTelefone}/messages", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {TokenAcessoUsuario}");

            return request;
        }


        public static void EnviarMensagem(string numeroPessoa, bool temVariaveis, bool temBotao, string templateMensagem, eTipoCabecalho tipoCabecalho, string variaveisCorpo = "", string linkArquivo = "", string nomeArquivo = "") {
            EnviarMensagem(numeroPessoa, temVariaveis, temBotao, templateMensagem, tipoCabecalho, "", variaveisCorpo, linkArquivo, nomeArquivo);
        }

        /// <summary>
        /// Envio mensagem definida pelo template criado na API do WhatsApp.
        /// É preciso que seja gerado um link do boleto, pois a API não permite caminho local.
        /// </summary>
        /// <param name="numeroPessoa">Numero de telefone do Cliente. Formatação aceita: Código do país + DDD + Número (5517999999999)</param>
        /// <param name="temVariaveis">Indica se tem variáveis no template</param>
        /// <param name="temBotao">Indica se tem botões no template</param>
        /// <param name="templateMensagem">Nome do template da mensagem criada</param>
        /// <param name="tipoCabecalho">Tipo do cabeçalho da mensagem (Texto ou Documento)</param>
        /// <param name="variaveisCabecalho">Valores que irão preencher as variáveis criadas no cabeçalho, separados por vírgula</param>
        /// <param name="variaveisCorpo">Valores que irão preencher as variáveis criadas no corpo, separados por vírgula</param>
        /// <param name="linkArquivo">Link do arquivo a ser enviado (Apenas o valor variável)</param>
        /// <param name="nomeArquivo">Nome do arquivo (apenas o valor variável)</param>
        public static void EnviarMensagem(string numeroPessoa, bool temVariaveis, bool temBotao, string templateMensagem, eTipoCabecalho tipoCabecalho, string variaveisCabecalho = "", string variaveisCorpo = "", string linkArquivo = "", string nomeArquivo = "")
        {
            if (templateMensagem == "")
            {
                throw new Exception("Template da mensagem precisa ser informado.");
            }
            string numeroFormatado = FormatarNumero(numeroPessoa);

            RestClient client = GetClient();
            RestRequest request = GetRequisicao();
            string body = MontaCorpoRequisicao(numeroPessoa, temVariaveis, temBotao, templateMensagem, tipoCabecalho, variaveisCabecalho, variaveisCorpo, linkArquivo, nomeArquivo);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Erro ao enviar mensagem.{response.Content}");
            }
        }

        /// <summary>
        /// Monta o corpo da requisição
        /// </summary>
        /// <param name="numeroPessoa">Numero da pessoa</param>
        /// <param name="temVariaveis">Indica se tem variáveis no template</param>
        /// <param name="temBotao">Indica se tem botões no template</param>
        /// <param name="templateMensagem">Nome do template da mensagem criada</param>
        /// <param name="tipoCabecalho">Tipo do cabeçalho da mensagem (Texto ou Documento)</param>
        /// <param name="varCabecalho">Variáveis a serem utilizadas no cabeçalho da mensagem como parâmetros</param>
        /// <param name="varCorpo">Variáveis a serem utilizadas no corpo da mensagem como parâmetros</param>
        /// <param name="linkArquivo">Link do arquivo (Apenas o ID)</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <returns></returns>
        private static string MontaCorpoRequisicao(string numeroPessoa, bool temVariaveis, bool temBotao, string templateMensagem, eTipoCabecalho tipoCabecalho, string varCabecalho = "", string varCorpo = "", string linkArquivo = "", string nomeArquivo = "")
        {
            string body = "";
            bool temCabecalho = false, temVarCorpo = false;
            string[] variaveisCabecalho = varCabecalho.Split(','), variaveisCorpo = varCorpo.Split(',');

            body = "{" +
                    "\"messaging_product\": \"whatsapp\"," +
                    $"\"to\": \"{numeroPessoa}\"," +
                    "\"type\": \"template\"," +
                    "\"template\": {" +
                    $"\"name\": \"{templateMensagem}\"," +
                    "\"language\": {" +
                    "\"code\": \"pt_BR\"" +
                    "}";

            if (temVariaveis)
            {
                body += "," +
                    "\"components\": [";

                if (tipoCabecalho == eTipoCabecalho.Documento)
                {
                    temCabecalho = true;
                    body +=
                        "{" +
                        "    \"type\": \"header\"," +
                        "    \"parameters\": [" +
                        "        {" +
                        "            \"type\": \"document\"," +
                        "            \"document\": {" +
                        $"                \"filename\": \"{nomeArquivo}\"," +
                        $"                \"link\": \"{linkArquivo}\"" +
                        "            }" +
                        "        }" +
                        "    ]" +
                        "}";
                }
                else if (tipoCabecalho == eTipoCabecalho.Texto)
                {
                    if (variaveisCabecalho?.Length > 0)
                    {
                        temCabecalho = true;

                        body +=
                            "{" +
                            "  \"type\": \"header\"," +
                            "  \"parameters\": [";

                        for (int i = 0; i < variaveisCabecalho?.Length; i++)
                        {
                            body +=
                        "{" +
                        "   \"type\": \"text\"," +
                        $"  \"text\": \"{variaveisCabecalho[i]}\"" +
                        "}";

                            if (i + 1 <= variaveisCabecalho?.Length - 1)
                            {
                                body += ",";
                            }
                        }

                        body += "]" + "}";
                    }
                }

                if (variaveisCorpo?.Length > 0)
                {
                    temVarCorpo = true;
                    if (temCabecalho)
                    {
                        body += ",";
                    }

                    body +=
                        "{" +
                        "    \"type\": \"body\"," +
                        "    \"parameters\": [";

                    for (int i = 0; i < variaveisCorpo?.Length; i++)
                    {
                        body +=
                        "{" +
                        "   \"type\": \"text\"," +
                        $"  \"text\": \"{variaveisCorpo[i]}\"" +
                        "}";

                        if (i + 1 <= variaveisCorpo?.Length - 1)
                        {
                            body += ",";
                        }
                    }

                    body += "]" + "}";
                }

                if (temBotao)
                {
                    if (temVarCorpo)
                    {
                        body += ",";
                    }

                    body +=
                        "{" +
                        "   \"type\": \"button\"," +
                        "   \"sub_type\": \"url\"," +
                        "   \"index\": \"0\"," +
                        "   \"parameters\": [" +
                        "      {" +
                        "        \"type\": \"text\"," +
                        $"       \"text\": \"{linkArquivo}\"" +
                        "      }" +
                        "     ]" +
                        "}";
                }

                body += "]";
            }

            body += "}" + "}";

            return body;
        }

        /// <summary>
        /// Formata o número de acordo com o padrão que o WhatsApp exige
        /// </summary>
        /// <param name="numeroPessoa"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string FormatarNumero(string numeroPessoa)
        {
            string numeroLimpo = new string(numeroPessoa.Where(c => char.IsDigit(c)).ToArray());
            numeroLimpo = numeroLimpo.Substring(0, 2) != "55" ? "55" + numeroLimpo : numeroLimpo;
            if (numeroLimpo.Length < 13 || numeroLimpo.Length > 14)
            {
                throw new Exception("Número inválido.");
            }

            return numeroLimpo;
        }
    }
}
