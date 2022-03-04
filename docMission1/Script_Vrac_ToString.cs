 /// Overload Method
        public string MentionsProducts(string mention)
        {
            return mention;
        }


        /// <summary>
        ///  Overload Method for BASE product
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="dlu"></param>
        /// <param name="mention"></param>
        /// <returns></returns>
        public string MentionsProducts(string ingredient, string dlu, string mention)
        {
            string str = "Ingrédients: " + ingredient + "\r\nA utiliser de préf. avant fin : " + dlu + mention;
            return str;
        }


        /// <summary>
        /// Overload method for vegetable oil products
        /// </summary>
        /// <param name="inci"></param>
        /// <param name="dlu"></param>
        /// <param name="mention"></param>
        /// <param name="risque"></param>
        /// <returns></returns>
        public string MentionsProducts(string inci, string dlu, string mention, string risk)
        {
            string str = "Ingrédient cosmétique                                                              Désignation INCI : " + inci + "\r\nA utiliser de préf. avant fin :" + dlu + "                                                                         " + mention + risk+ "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            return str;
        }


        /// <summary>
        /// Overload method for soap products
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="pao"></param>
        /// <param name="mention"></param>
        /// <returns></returns>
        public string MentionsProducts(string ingredient, int pao, string mention)
        {
            string str = "Ingrédients : " + ingredient + "\r\nPAO : " + pao + " mois\r\n" + mention;
            return str;
        }


        /// <summary>
        /// ToString method for formatted datas
        /// </summary>
        /// <param name="endrow"></param>
        /// <returns>string with data</returns>
        public override string ToString()
        {
            string str = Vracno + "\r\nnom = " + name + "\r\ncategorie = " + category + "\r\ndescription = '''" + description;
            str += "'''\r\nlot = " + lot + "\r\nprix = " + price + "\r\nproducteur = " + origin + "\r\ndensite = " + density;
            str += "\r\nnumero = " + number + "\r\nlogos = " + logo;

            return str;

        }
