using System;
using System.ComponentModel.DataAnnotations;

namespace Nps.Models
{
    public class NpsCalc
    {
        [Range(1, 9999999, ErrorMessage ="valor inválido")]
        [Display(Name ="Clientes")]
        [Required(ErrorMessage ="o valor é obrigatório")]
        public int Customers { get; set; }


        [Range(1, 9999999, ErrorMessage = "valor inválido")]
        [Required(ErrorMessage = "o valor é obrigatório")]
        public int Promoters { get; set; }

        [Range(1, 9999999, ErrorMessage = "valor inválido")]
        [Required(ErrorMessage = "o valor é obrigatório")]
        public int Neutrals { get; set; }

        [Range(1, 9999999, ErrorMessage = "valor inválido")]
        [Required(ErrorMessage = "o valor é obrigatório")]
        public int Detractors { get; set; }

        public int SampleSize()
        {
            double x90 = Math.Pow(2.57 / 0.02, 2) * 0.5 * 0.5;
            return (int)((Customers * x90) / (Customers + x90));
        }

        public int Sends()
        {
            return (int)(Customers / 0.25);
        }

        public double Total()
        {
            return Detractors + Promoters + Neutrals;
        }

        public int NPS()
        {
            return (int)(100 * (Promoters - Detractors) / Total());
        }

        public double VarNPS()
        {
            return Detractors / Total() * Math.Pow((-1.0 - NPS() / 100.0), 2) + Neutrals / Total() * Math.Pow((-NPS() / 100.0), 2) + Promoters / Total() * Math.Pow((1.0 - NPS() / 100.0), 2);
        }

        public double MoeNPS95()
        {
            return (100 * Math.Sqrt(VarNPS() / Total())) * 1.96;
        }

        public double MoeNPS99()
        {
            return (100 * Math.Sqrt(VarNPS() / Total())) * 2.57;
        }

        public  int[] Interval95()
        {
            int inf = (int)(NPS() - MoeNPS95());
            int sup = (int)(NPS() + MoeNPS95());

            int[] values = { inf, sup };

            return values;
        }

        public int[] Interval99()
        {
            int inf = (int)(NPS() - MoeNPS99());
            int sup = (int)(NPS() + MoeNPS99());

            int[] values = {inf, sup};

            return values;
        }
    }
}
