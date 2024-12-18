﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplPaswKeys.MYMODELS
{
    public class SIFRELER
    {

        public class SIFRE
        {
            public int sif_RECno = 0;                            //başlarına static eklenince .dan sonra çıkmıyorlar bu yüzden statici kaldırdım.
            public string sif_site_adi = "";
            public string sif_site_url = "";
            public string sif_kul_adi_mail = "";
            public string sif_kul_sifre = "";
            public string sif_notlar = "";
        }
        public static int SIFRE_Kaydet(SIFRE sif)
        {
            
            if (sif.sif_RECno == 0)
            {
                int recno = Convert.ToInt32(CLS.SQLConnectionClass.Command(""
            + "                INSERT INTO[dbo].[SIFRELER]           "
            + "       ([sif_site_adi]                                "
            + "       , [sif_site_url]                               "
            + "       , [sif_kul_adi_mail]                           "
            + "       , [sif_kul_sifre]                              "
            + "       , [sif_notlar]                                 "
            + "       , [sif_kayit_tarih]                            "
            + "       , [sif_guncelleme_tarih])                      "
            + "OUTPUT  INSERTED.sif_RECno" 
            + "            VALUES                                    "
            + "       ('" + sif.sif_site_adi + "'                "
            + "       ,'" + sif.sif_site_url + "'           "
            + "       ,'" + sif.sif_kul_adi_mail + "'           "
            + "       ,'" + sif.sif_kul_sifre + "'           "
            + "       ,'" + sif.sif_notlar + "'           "
            + "       ,getdate()                 "
            + "       ,getdate()  );         "));
                
                
                MessageBox.Show("kayıt başarılı");
                return recno;

            }
            else
            {
                CLS.SQLConnectionClass.Command(""
               + "                UPDATE INTO[dbo].[SIFRELER]   set        "
               + "       ([sif_site_adi]                        =      '"+sif.sif_site_adi+"'                "
               + "       , [sif_site_url]                       =      '"+sif.sif_site_url + "'           "
               + "       , [sif_kul_adi_mail]                   =      '"+sif.sif_kul_adi_mail + "'           "
               + "       , [sif_kul_sifre]                      =      '"+sif.sif_kul_sifre + "'           "
               + "       , [sif_notlar]                         =      '"+sif.sif_notlar + "'           "
               + "       , [sif_kayit_tarih]                    =      getdate()                 "
               + "       , [sif_guncelleme_tarih])              =      getdate()  );         "
               + "            WHERE sif_RECno ="+ sif.sif_RECno + "                                   "


               );
                return sif.sif_RECno;
                MessageBox.Show("Güncelleme Başarılı");
            }   
        }
        public static void SIFRE_Sil(int recno)
        {
            CLS.SQLConnectionClass.Command(""
              + "DELETE FROM [dbo].[SIFRELER]   WHERE sif_RECno =" + recno + "");
            
            MessageBox.Show("Silme Başarılı");
            
            
        }
    }
}
