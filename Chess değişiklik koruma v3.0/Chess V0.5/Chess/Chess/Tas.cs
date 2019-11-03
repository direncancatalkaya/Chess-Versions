using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public abstract class Tas
    {

        public Tas()
        {
            İsMoved = 0;
        }

        public List<Kordinat> KordinatsCanGo = new List<Kordinat>();
        protected TasTipi _TasTİpi;
        protected bool _İsBlack;
        protected string _BackGroundİmage;
        protected Tasİd _Tasid;

        public Kordinat TasKordinat { get; set; }
        public TasTipi TasTipi { get { return _TasTİpi; } }
        public int İsMoved { get;protected set; }
        public bool StopTry { get; set; }
        public bool İsBlack { get { return _İsBlack; } }
        public string Backgroundİmage { get { return _BackGroundİmage; } }
        public Tasİd Tasid { get { return _Tasid; } set { _Tasid = value; } }



        /// <summary>
        /// Siyah Ve Beyaz Taşların Tüm atak yaptığı kareleri kordinat olarak listeye yazar ..
        /// </summary>
        public void FillAttackList()  
        {
            Form1.BlackAttacks.Clear();
            Form1.WhiteAttacks.Clear();

            foreach (Tas item in Form1.MevcutTaslar)
            {
                if (item.İsBlack)
                {
                    foreach (Kordinat VARIABLE in item.KordinatsCanGo)
                    {
                        if (VARIABLE.KordinatType==KordinatType.Attack) Form1.BlackAttacks.Add(VARIABLE);
                    }
                }

                if (!item.İsBlack)
                {
                    foreach (Kordinat VARIABLE in item.KordinatsCanGo)
                    {
                        if (VARIABLE.KordinatType==KordinatType.Attack) Form1.WhiteAttacks.Add(VARIABLE);
                    }
                }
            }
        }

        /// <summary>
        /// Taşı Hedef Konuma Götürür ve Buttonun çizim işlemlerini yapar , Taş Yenecekse Yer , Gidilecek Kare Boşsa Sadece gider
        /// </summary>
        /// <param name="x">X kordinatı</param>
        /// <param name="y">Y kordinatı</param>
        public virtual void Move(int x, int y)
        {
            int OldX = TasKordinat.X, OldY = TasKordinat.Y;

            foreach (Kordinat VARIABLE in KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y)
                {
                    if (Form1.Squares[y, x].Tas != null)
                    {
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        TasKordinat.X = x;
                        TasKordinat.Y = y;
                        Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        İsMoved += 1;
                        MakeCangoList();
                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
                        break;

                    }
                    else
                    {
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        TasKordinat.X = x;
                        TasKordinat.Y = y;
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        İsMoved += 1;
                        MakeCangoList();
                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
                        break;
                    }
                }
            }

            FillAllCanGoList();
            FillAttackList();

            if (İsEnemyKingDanger())
            {
                int a = İsCheckMate();

                if (a < 3)
                {
                    MessageBox.Show("Şah Mat .. Oyun Bitti Tebrikler ..");
                }
                else if (a > 0)
                {
                    MessageBox.Show("Şah..");
                }
            }

            Piyon.AllPiyonisMoveUp();
        }

        /// <summary>
        /// Herhangi Bi Koşula bakmaksızın Belirtilen Kordinata gider.. taş varsa yer yoksa sadece gider.. (Dikkat! : sadece Rok için Tasarlandı  )
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public virtual void MoveNonCheck(int x, int y)
        {
            if (Form1.Squares[y, x].Tas == null)
            {
                Form1.Squares[TasKordinat.Y, TasKordinat.X].Tas = null;
                Form1.Squares[TasKordinat.Y, TasKordinat.X].GetBackgroundİmage();
                Form1.Squares[TasKordinat.Y, TasKordinat.X].Dolumu = false;
                TasKordinat.X = x;
                TasKordinat.Y = y;
                Form1.Squares[y, x].Tas = this;
                Form1.Squares[y, x].GetBackgroundİmage();
                Form1.Squares[y, x].Dolumu = true;
                İsMoved += 1;
                MakeCangoList();
            }
            else
            {
                Form1.Squares[TasKordinat.Y, TasKordinat.X].Tas = null;
                Form1.Squares[TasKordinat.Y, TasKordinat.X].GetBackgroundİmage();
                Form1.Squares[TasKordinat.Y, TasKordinat.X].Dolumu = false;
                TasKordinat.X = x;
                TasKordinat.Y = y;
                Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
                Form1.Squares[y, x].Tas = this;
                Form1.Squares[y, x].GetBackgroundİmage();
                Form1.Squares[y, x].Dolumu = true;
                İsMoved += 1;
                MakeCangoList();
            }

            FillAllCanGoList();
            FillAttackList();


            if (İsEnemyKingDanger())
            {
                int a = İsCheckMate();

                if (a < 3)
                {
                    MessageBox.Show("Şah Mat .. Oyun Bitti Tebrikler ..");
                }
                else if (a > 0)
                {
                    MessageBox.Show("Şah..");
                }
            }

            Piyon.AllPiyonisMoveUp();

        }

        /// <summary>
        /// Sadece Rok için  kullanılabilir. Karelerin Boş ve atak altında olup olmadığına bakar ..
        /// </summary>
        /// <param name="Hedef X kordinatı"></param>
        /// <param name="Hedef Y Kordinatı"></param>
        /// <returns></returns>
        public bool İsSquareİnDanger(int x, int y)
        {
            if (İsBlack)
            {
                foreach (Kordinat VARIABLE in Form1.WhiteAttacks)
                {
                    if (VARIABLE.X == x && VARIABLE.Y == y || Form1.Squares[y, x].Dolumu)
                    {
                        return true;
                    }

                }

            }


            else if (!İsBlack)
            {
                foreach (Kordinat VARIABLE in Form1.BlackAttacks)
                {
                    if (VARIABLE.X == x && VARIABLE.Y == y || Form1.Squares[y, x].Dolumu)
                    {
                        return true;
                    }

                }

            }


            return false;
        }

        /// <summary>
        ///  Taşın Kendi Şahı Tehlikedemi KOntrol eder ..True ise tehlikede demektir ..
        /// </summary>
        /// <returns></returns>
        public bool İsKingDanger() 
        {
            bool a = false;
            if (İsBlack)
            {
                foreach (Kordinat VARIABLE in Form1.WhiteAttacks)
                {
                    if (VARIABLE == Form1.SiyahSah.TasKordinat)
                    {
                        a = true;
                    }
                }
            }
            else
            {
                foreach (Kordinat VARIABLE in Form1.BlackAttacks)
                {
                    if (VARIABLE == Form1.BeyazSah.TasKordinat)
                    {
                        a = true;
                    }

                }
            }
            return a;
        }

        /// <summary>
        /// Karşı Şah Tehdit Altındamı Kontrol eder .. True ise Tehdit Altında demektir ..
        /// </summary>
        /// <returns></returns>
        public bool İsEnemyKingDanger()
        {
            bool a = false;
            if (İsBlack)
            {
                foreach (Kordinat VARIABLE in Form1.BlackAttacks)
                {
                    if (VARIABLE == Form1.BeyazSah.TasKordinat)
                    {
                        a = true;
                    }

                }
            }
            else
            {
                foreach (Kordinat VARIABLE in Form1.WhiteAttacks)
                {
                    if (VARIABLE == Form1.SiyahSah.TasKordinat)
                    {
                        a = true;
                    }

                }
            }

            return a;
        }

        /// <summary>
        /// Tahtadaki Tüm Taşların Gidebileceği kareler listesini doldurur .. ( Yeniler. Üzerine yazmaz ) 
        /// </summary>
        public static void FillAllCanGoList()
        {

            foreach (Tas VARIABLE in Form1.MevcutTaslar)
            {
                VARIABLE.MakeCangoList();
            }


        }  

        /// <summary>
        /// Belirtilen Konuma Taşın Gidip Gidemeyeceğini Kontrol Eder
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool CanGo(int x, int y) 
        {

            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu)
            {
                return true;
            }
            if (Form1.Squares[y, x].Dolumu && (TargetİsBlack(x, y) != İsBlack))
            {
                StopTry = true;
                return true;

            }


            StopTry = true;
            return false;





        }

        /// <summary>
        /// Hedef Konumdaki Taş Rengini Alır
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool TargetİsBlack(int x, int y)
        {
            x = x > 7 ? 7 : x;
            y = y > 7 ? 7 : y;
            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            if (Form1.Squares[y, x].Tas.İsBlack)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Taşın Gidebileceği Kareler Listesini Yenilen
        /// </summary>
        public abstract void MakeCangoList();

        /// <summary>
        /// Taşı verilen Konuma Deneme Olarak Götürür .. Şah tehdit altında kalıyormu diye kontrol eder .. Gerçek bir Hamle İşlemi Gerçekleştirme .. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool FakeMove(int x, int y)
        {


            bool EverythingİsOk = true;
            FillAllCanGoList();
            FillAttackList();

            int OldX = TasKordinat.X, OldY = TasKordinat.Y;



            foreach (Kordinat VARIABLE in KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y)
                {
                    if (Form1.Squares[y, x].Tas != null)
                    {
                        Tas CopyTarget = Form1.Squares[y, x].Tas;
                        CopyTarget.TasKordinat.X = 10;
                        CopyTarget.TasKordinat.Y = 10;
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        TasKordinat.X = x;
                        TasKordinat.Y = y;
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        FillAllCanGoList();
                        FillAttackList();
                        if (İsKingDanger())
                        {
                            EverythingİsOk = false;
                        }

                        Form1.Squares[OldY, OldX].Tas = this;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = true;
                        TasKordinat.X = OldX;
                        TasKordinat.Y = OldY;
                        CopyTarget.TasKordinat.X = x;
                        CopyTarget.TasKordinat.Y = y;
                        Form1.Squares[y, x].Tas = CopyTarget;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        break;

                    }
                    else
                    {
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        TasKordinat.X = x;
                        TasKordinat.Y = y;
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        FillAllCanGoList();
                        FillAttackList();
                        if (İsKingDanger())
                        {
                            EverythingİsOk = false;
                        }


                        Form1.Squares[OldY, OldX].Tas = this;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = true;
                        TasKordinat.X = OldX;
                        TasKordinat.Y = OldY;
                        Form1.Squares[y, x].Tas = null;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = false;
                        break;
                    }


                }
            }


            return EverythingİsOk;

        }

        /// <summary>
        /// Her Bir Taş Oynandığında Eğer Karşı Şahı tehdit Etmişse karşının Yapabileceği Her hamle Denenir ve bu hamleler sonucunda Karşı Şah hala kurtulamıyorsa Şah Mat verilir ..
        /// </summary>
        /// <returns></returns>
        public int İsCheckMate() 
        {
            List<Kordinat> TempKord = new List<Kordinat>();
            int a = 0;


            if (İsBlack)
            {
                foreach (Tas VARIABLE in Form1.MevcutTaslar)
                {
                    TempKord.Clear();
                    if (!VARIABLE.İsBlack)
                    {
                        foreach (Kordinat item in VARIABLE.KordinatsCanGo)
                        {
                            TempKord.Add((Kordinat)item.Clone());
                        }

                        foreach (Kordinat asd in TempKord)
                        {
                            if (VARIABLE.FakeMove(asd.X, asd.Y))
                            {
                                a += 3;
                            }
                            FillAllCanGoList();
                            FillAttackList();
                        }
                    }
                }
            }

            else

            {



                foreach (Tas VARIABLE in Form1.MevcutTaslar)
                {
                    TempKord.Clear();
                    if (VARIABLE.İsBlack)
                    {
                        foreach (Kordinat item in VARIABLE.KordinatsCanGo)
                        {
                            TempKord.Add((Kordinat)item.Clone());
                        }

                        foreach (Kordinat asd in TempKord)
                        {

                            if (VARIABLE.FakeMove(asd.X, asd.Y))
                            {
                                a += 3;
                            }
                            FillAllCanGoList();
                            FillAttackList();

                        }
                    }
                }
            }


            return a;




        }

    }



    public enum TasTipi
    {
        Kale,
        Sah,
        Piyon,
        Fil,
        At,
        Vezir,

    }


    public enum Tasİd
    {
        SiyahKisaKale,
        SiyahUzunKale,
        BeyazKisaKale,
        BeyazUzunKale,
        SiyahSah,
        BeyazSah,
        Diger
    }

}
