using System;
using System.Collections.Generic;
using System.Text;

namespace SCCE.Models
{
    public class BombaSubmersaItem
    {
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string NumeroPatrimonio { get; set; }
        public string Potencia { get; set; }
        public string[] VazaoNominal { get; set; }
        public string CorrenteNominal { get; set; }
        public string VazaoServico { get; set; }
        public string CorrenteServico { get; set; }
        public string NivelDinamico { get; set; }
        public string NivelEstatico { get; set; }
        public string DataInstalacao { get; set; }
        public string[] AlturaManometricaNominal { get; set; }
        public string TensaoNominal { get; set; }
        public string PressaoServico { get; set; }
        public string TensaoServico { get; set; }
        public string AlturaManometricaServico { get; set; }
        public string DesnivelGeometrico { get; set; }
        public string ProfundInstal { get; set; }
        public string Obs { get; set; }

    }
}
