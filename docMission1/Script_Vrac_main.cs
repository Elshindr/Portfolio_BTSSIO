public override void Entrée0_ProcessInputRow(Entrée0Buffer Row){
    // Variable for overload
        string no = Row.no;

        // Variables for builder
        string id = "[" + Row.vracno + "]";
        string name = Row.name;
        string category = Row.category;
        string description = "";
        string number = Row.vracno;
        string price = Row.price;
        string origin = Row.origin;
        string density = Row.density;
        string lot = Row.lot ;
        string logo = Row.logo;

        //Variables for description and specifiques mentions
        string inci = Row.scientificdescription;
        string ingredient = Row.ingredients;
        string dlu = Row.dlu;
        int pao = Row.pao;


        // Variables à modifier
        string mention = Row.emploi;
        string risks = "";


        Bulk newBulk = new Bulk(id, name, category, description, number, price, origin, density, lot, logo, mention, risks);

        if (no.Substring(0, 4) == "BASE")
        {
            newBulk.Description = newBulk.MentionsProducts(ingredient, dlu, mention);
        }

        if (no.Substring(0, 2) == "HV")
        {
            mention = "Ne pas avaler. Tenir hors de portée des enfants. Stocker a l abri de la chaleur et de la lumiere.";
            if(no == "HV0074V")
            {
                risks = "Huile puissante, à utiliser diluée. Prudence sur peaux et cuirs chevelus sensibles.";
            }
           
            newBulk.Description = newBulk.MentionsProducts(inci, dlu, mention, risks);
        }

        if (no.Substring(0, 3) == "SAV")
        {
            newBulk.Description = newBulk.MentionsProducts(ingredient, pao, mention);
        }

        Sortie0Buffer.AddRow();
        Sortie0Buffer.lstProducts = newBulk.ToString();

    }
