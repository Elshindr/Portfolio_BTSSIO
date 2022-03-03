 class LigneFormat
    {
        // Links columns by variables
        string shop;
        string libelle;
        string nbCpt;
        int totalOperation;
        DateTime dtDate;

        // Variables for builder
        string numOp;
        string typeOp;
        int SensOp = 2;
        string strPrice;
       
        public LigneFormat(string shop, DateTime dtDate, string nbCpt, string libelle, float fltPrice, int totalOperation)
        {
            this.shop = shop;
            this.libelle = libelle + " " + dtDate.Day + dtDate.ToString("MM") + dtDate.Year; ;
            this.nbCpt = nbCpt;
            this.totalOperation = totalOperation;
            this.dtDate = dtDate;


            // Price is negatif AND Set sens operation
            if(fltPrice < 0)
            {
                fltPrice *= -1;
                if (nbCpt.Contains("707") || nbCpt.Contains("445713") || nbCpt.Contains("445715") || nbCpt.Contains("445716")) { SensOp = 1;}
                else{SensOp = 1;}
            }
            else {
                if (nbCpt.Contains("707") || nbCpt.Contains("445713") || nbCpt.Contains("445715") || nbCpt.Contains("445716"))  { SensOp = -1;}
                else{ SensOp = -1;}
            }

            strPrice = fltPrice.ToString().Replace(",", ".");          
        }

        override
        public string ToString()
        {
            string str = "";

            if (totalOperation <= 0){
                str += "G;FAC;;" + shop + ";VTE;" + dtDate.Year +  dtDate.ToString("MM") + dtDate.Day  + ";"+libelle+";EUR\r\n";
                totalOperation += 1; 
           
            }
            if (nbCpt.Contains("707"))
            {
                str += "D;" + totalOperation + ";" + 1 + ";" + shop + ";;" + nbCpt + ";;" + libelle + ";" + SensOp + ";" + strPrice + ";EUR\r\n";
                str += "D;" + totalOperation + ";" + 2 + ";" + shop + ";;" + nbCpt + ";;" + libelle + ";" + SensOp + ";" + strPrice + ";EUR\r\n";
                str += "A;" + 1 + ";AX1;1502;AX2;;AX3;" + shop + ";;;;;;;;;;;;;0;"+ strPrice ;
            }
            else if (nbCpt.Contains("445713") || nbCpt.Contains("445715") || nbCpt.Contains("445716"))
            {
                str += "D;" + totalOperation + ";" + 1 + ";" + shop + ";;" + nbCpt + ";;" + libelle + ";" + SensOp + ";" + strPrice + ";EUR";
            }
            else if (nbCpt.Contains("531000") || nbCpt.Contains("532000") || nbCpt.Contains("533000"))
            { 
                numOp = "411000";
                typeOp = nbCpt.Contains("531000") ? shop + "ESP" : nbCpt.Contains("532000") ? shop + "CHQ" : nbCpt.Contains("533000") ? shop + "CB" : "!UNK!";    
                str += "D;" + totalOperation + ";" + 1 + ";" + shop + ";C1;" + numOp + ";" + typeOp + ";" + libelle + ";" + SensOp + ";" + strPrice + ";EUR";      
             }
            else if (nbCpt.Contains("580000"))
            {
                numOp = "467500";
                str += "D;" + totalOperation + ";" + 1 + ";" + shop + ";;" + numOp + ";;" + libelle + ";" + 1 + ";" + strPrice + ";EUR";
            }

            else
            {
             str += "D;" + totalOperation + ";" + 1 + ";" + shop + ";;" + nbCpt + ";;" + libelle + ";" + "2" + ";" + strPrice + ";EUR";

            }
            
            
            return str;
        }
    }