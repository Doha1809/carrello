using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
namespace carrello
{
    public partial class Form1 : Form
    {
        Carrello carrello = new Carrello("ciao");
        Prodotto p = new Prodotto("123", "321", "12", 1.20);
        public Form1()
        {
            InitializeComponent();
            pictureBox5.Visible = false;
            pictureBox4.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            carrello.Aggiungi_prodotto(p);
            pictureBox5.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            carrello.Svuota_carrello();
            if (carrello.conta /2==0)
                pictureBox4.Visible = true;
            else
                pictureBox5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carrello.Elimina_prodotto(p);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
class Prodotto
{
    
    private string id;
    public string Id
    {
        get {  return id; }
    }
    private string marca;
    public string Marca
    {
        get { return marca; }
    }
   /* private string modello;
    public string Modello
    {
        get { return modello; }
    }*/
    private double prezzo;
    public double Prezzo
    {
        get { return prezzo; }
        set { prezzo = value; }
    }
   public  Prodotto(string id, string marca, string modello, double prezzo)
    {
        this.id = id;
        this.marca= marca;
        
        this.prezzo= prezzo;
    }
}
class Carrello
{
    private string id;
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public object Properties { get; internal set; }

    public Carrello(string id)
    {
        this.id = id;
    }
    List<Prodotto> prodotti = new List <Prodotto> ();
    public int conta;
    public void Aggiungi_prodotto(Prodotto p)
    {
        prodotti.Add(p);
        MessageBox.Show("Prodotto aggiunto");
       conta= prodotti.IndexOf(p);
        MessageBox.Show(Convert.ToString(prodotti.Count));
    }
    public int trovato = -1;
    public void Elimina_prodotto(Prodotto P)
    {
            for (int i = 0; i < prodotti.Count; i++)
            {
                if (prodotti[i].Id == P.Id)
                {
                    trovato = i;
                     i = i - 1; //così viene controllato anche l'elemento che sostituisce l'elemento elemenato'
                    prodotti.RemoveAt(trovato);
                    MessageBox.Show("prodotto eleminato");
      
                    
                }
            }
        
    }
    public void Svuota_carrello()
    {
        if (prodotti.Count > 0)
        {
            prodotti.Clear();
            MessageBox.Show("carrello svuotato");
        }
    }

}