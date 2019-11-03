using System;
using System.Collections.Generic;
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
            this.İsMoved = false;
        }
        public List<Kordinat> KordinatsCanGo = new List<Kordinat>();
        protected TasTipi _TasTİpi;
        protected bool _İsBlack;
        protected string _BackGroundİmage;
        public int İd { get; set; }
        public Kordinat TasKordinat { get; set; }
        public TasTipi TasTipi { get { return _TasTİpi; } }
        public bool İsMoved { get; protected set; }
        public bool StopTry { get; set; }
        public bool İsBlack { get { return _İsBlack; } }
        public string Backgroundİmage { get { return _BackGroundİmage; } }




        public void FillAttackList()  // Siyah Ve Beyaz Taşların Tüm atak yaptığı kareleri kordinat olarak listeye yazar ..
        {
            Form1.BlackAttacks.Clear();
            Form1.WhiteAttacks.Clear();

            foreach (Tas item in Form1.MevcutTaslar)
            {
                if (item.İsBlack)
                {

                    foreach (Kordinat VARIABLE in item.KordinatsCanGo)
                    {
                        if (VARIABLE.Attack) Form1.BlackAttacks.Add(VARIABLE);
                    }


                }

                if (!item.İsBlack)
                {
                    foreach (Kordinat VARIABLE in item.KordinatsCanGo)
                    {
                        if (VARIABLE.Attack) Form1.WhiteAttacks.Add(VARIABLE);
                    }


                }
            }
        }

        public virtual void Move(int x, int y)  // Taşı Hedef Konuma Götürür ve Buttonun çizim işlemlerini yapar ..
        {
            //FillAllCanGoList();
            //FillAttackList();
            if (!FakeMove(x, y))
            {
                MessageBox.Show("Şah Tehdit Altında Kalıyor Bu hamle yapılamaz..");
                FillAllCanGoList();
                FillAttackList();
                return;
            }

            FillAllCanGoList();
            FillAttackList();



            int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;



            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y)
                {
                    if (Form1.Squares[y, x].Tas != null)
                    {
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        this.TasKordinat.X = x;
                        this.TasKordinat.Y = y;
                        Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        this.İsMoved = true;
                        this.MakeCangoList();
                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
                        break;

                    }
                    else
                    {
                        Form1.Squares[OldY, OldX].Tas = null;
                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
                        Form1.Squares[OldY, OldX].Dolumu = false;
                        this.TasKordinat.X = x;
                        this.TasKordinat.Y = y;
                        Form1.Squares[y, x].Tas = this;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = true;
                        this.İsMoved = true;
                        this.MakeCangoList();
                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
                        break;
                    }


                }
            }
            FillAllCanGoList();
            FillAttackList();


            if (İsEnemyKingDanger())
            {
                int a = this.İsCheckMate();

                if (a < 3)
                {
                    MessageBox.Show("Şah Mat .. Oyun Bitti Tebrikler ..");
                }
                else if (a > 0)
                {
                    MessageBox.Show("Şah..");
                }
            }







        }

        public bool İsKingDanger() // Taşın Kendi Şahı Tehlikedemi KOntrol eder ..True ise tehlikede demektir ..
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

        public bool İsEnemyKingDanger() // Karşı Şah Tehdit Altındamı Kontrol eder .. True ise Tehdit Altında demektir ..
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

        public static void FillAllCanGoList()
        {

            foreach (Tas VARIABLE in Form1.MevcutTaslar)
            {
                VARIABLE.MakeCangoList();
            }


        }  // Tahtadaki Tüm Taşların Gidebileceği kareler listesini doldurur .. ( Yeniler. Üzerine yazmaz ) 

        public virtual bool CanGo(int x, int y)  //Taşın Gideceği Konuma Gidip Gidemeyeceğini Kontrol eder .
        {

            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu)
            {
                return true;
            }
            if (Form1.Squares[y, x].Dolumu && (TargetİsBlack(x, y) != this.İsBlack))
            {
                this.StopTry = true;
                return true;

            }


            this.StopTry = true;
            return false;





        }

        public virtual bool TargetİsBlack(int x, int y) // Hedef Konumdaki Taş rengini alır ..
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

        public abstract void MakeCangoList(); // taşın gidebileceği Karelerin Listesini yeniler ..

        public virtual bool FakeMove(int x, int y)
        {


            bool EverythingİsOk = true;
            FillAllCanGoList();
            FillAttackList();

            int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;



            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
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
                        this.TasKordinat.X = x;
                        this.TasKordinat.Y = y;
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
                        this.TasKordinat.X = OldX;
                        this.TasKordinat.Y = OldY;
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
                        this.TasKordinat.X = x;
                        this.TasKordinat.Y = y;
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
                        this.TasKordinat.X = OldX;
                        this.TasKordinat.Y = OldY;
                        Form1.Squares[y, x].Tas = null;
                        Form1.Squares[y, x].GetBackgroundİmage();
                        Form1.Squares[y, x].Dolumu = false;
                        break;
                    }


                }
            }


            return EverythingİsOk;

        } // taşı verilen konuma deneme olarak götürür ve şah tehdit altına giriyormu kontrol eder .!!

        public int İsCheckMate()  //Her Bir Taş Oynandığında Eğer Karşı Şahı tehdit Etmişse karşının Yapabileceği Her hamle Denenir ve bu hamleler sonucunda Karşı Şah hala kurtulamıyorsa Şah Mat verilir ..
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

}
