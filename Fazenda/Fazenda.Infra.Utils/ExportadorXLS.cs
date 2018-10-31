using Fazenda.Dominio.Features.Despesas;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Fazenda.Infra.Utils
{
    public class ExportadorXLS
    {
        private static HSSFWorkbook _documento;
        public static void ExportarListaDeDespesas(ICollection<Despesa> despesas, string path)
        {
            FileStream file = new FileStream(ConfigurationManager.AppSettings["TemplateArquivoExcelDespesas"], FileMode.Open, FileAccess.Read);
            _documento = new HSSFWorkbook(file);
            PreencherInformacoesDespesas(despesas);
            FinalizarGravacaoArquivo(path);
        }

        private static void FinalizarGravacaoArquivo(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                _documento.Write(file);
                file.Close();
            }
        }

        private static void PreencherInformacoesDespesas(ICollection<Despesa> despesas)
        {
            ISheet sheetCatalogo = _documento.GetSheet("Despesas");

            int numeroProximaLinha = 4;
            double valorTotal = 0;
            foreach (Despesa despesa in despesas)
            {
                sheetCatalogo.GetCell(numeroProximaLinha, 1).SetCellValue(despesa.Data.ToShortDateString());
                sheetCatalogo.GetCell(numeroProximaLinha, 2).SetCellValue(despesa.PegarTipo());
                sheetCatalogo.GetCell(numeroProximaLinha, 3).SetCellValue(despesa.Fornecedor.Nome);
                sheetCatalogo.GetCell(numeroProximaLinha, 4).SetCellValue(despesa.Item.ToString());
                sheetCatalogo.GetCell(numeroProximaLinha, 5).SetCellValue(despesa.Quantidade);
                sheetCatalogo.GetCell(numeroProximaLinha, 6).SetCellValue(despesa.ValorUnitario);
                sheetCatalogo.GetCell(numeroProximaLinha, 7).SetCellValue(despesa.ValorTotal);
                if (despesa.Animal != null)
                    sheetCatalogo.GetCell(numeroProximaLinha, 8).SetCellValue(despesa.Animal.Especie);
                numeroProximaLinha++;
                valorTotal += despesa.ValorTotal;
            }
            numeroProximaLinha++;
            sheetCatalogo.GetCell(numeroProximaLinha, 7).SetCellValue(valorTotal);
        }
    }
}
