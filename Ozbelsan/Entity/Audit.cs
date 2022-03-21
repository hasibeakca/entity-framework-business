using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entity
{
   public abstract class Audit
    {
        public DateTime CDate { get; set; } = DateTime.Now; // OLUŞTURULAN ZAMAN
        public DateTime MDate { get; set; } // DEĞİŞTİRİLME TARİHİ
        public int CUserId { get; set; } //OLUŞTURULAN KİŞİ
        public int MUserId { get; set; } //DEĞİŞTİRİLEN KİŞİ
    }
}
