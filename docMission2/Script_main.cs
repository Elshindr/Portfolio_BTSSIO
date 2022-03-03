public class ScriptMain : UserComponent
{
    #region Help:  Using Integration Services variables and parameters
    /* To use a variable in this script, first ensure that the variable has been added to
     * either the list contained in the ReadOnlyVariables property or the list contained in
     * the ReadWriteVariables property of this script component, according to whether or not your
     * code needs to write into the variable.  To do so, save this script, close this instance of
     * Visual Studio, and update the ReadOnlyVariables and ReadWriteVariables properties in the
     * Script Transformation Editor window.
     * To use a parameter in this script, follow the same steps. Parameters are always read-only.
     *
     * Example of reading from a variable or parameter:
     *  DateTime startTime = Variables.MyStartTime;
     *
     * Example of writing to a variable:
     *  Variables.myStringVariable = "new value";
     */
    #endregion

    #region Help:  Using Integration Services Connnection Managers
    /* Some types of connection managers can be used in this script component.  See the help topic
     * "Working with Connection Managers Programatically" for details.
     *
     * To use a connection manager in this script, first ensure that the connection manager has
     * been added to either the list of connection managers on the Connection Managers page of the
     * script component editor.  To add the connection manager, save this script, close this instance of
     * Visual Studio, and add the Connection Manager to the list.
     *
     * If the component needs to hold a connection open while processing rows, override the
     * AcquireConnections and ReleaseConnections methods.
     * 
     * Example of using an ADO.Net connection manager to acquire a SqlConnection:
     *  object rawConnection = Connections.SalesDB.AcquireConnection(transaction);
     *  SqlConnection salesDBConn = (SqlConnection)rawConnection;
     *
     * Example of using a File connection manager to acquire a file path:
     *  object rawConnection = Connections.Prices_zip.AcquireConnection(transaction);
     *  string filePath = (string)rawConnection;
     *
     * Example of releasing a connection manager:
     *  Connections.SalesDB.ReleaseConnection(rawConnection);
     */
    #endregion

    #region Help:  Firing Integration Services Events
    /* This script component can fire events.
     *
     * Example of firing an error event:
     *  ComponentMetaData.FireError(10, "Process Values", "Bad value", "", 0, out cancel);
     *
     * Example of firing an information event:
     *  ComponentMetaData.FireInformation(10, "Process Values", "Processing has started", "", 0, fireAgain);
     *
     * Example of firing a warning event:
     *  ComponentMetaData.FireWarning(10, "Process Values", "No rows were received", "", 0);
     */
    #endregion


    // These global value let to keep in memory the number of operation after a row have been processed
    public int totalOperation = 0;



    /// <summary>
    /// This method is called once, before rows begin to be processed in the data flow.
    ///
    /// You can remove this method if you don't need to do anything here.
    /// </summary>
    public override void PreExecute()
    {
        
        base.PreExecute();
        /*
         * Add your code here
         */
 
    }

    /// <summary>
    /// This method is called after all the rows have passed through this component.
    ///
    /// You can delete this method if you don't need to do anything here.
    /// </summary>
    public override void PostExecute()
    {
        base.PostExecute();
        /*
         * Add your code here
         */
    }

    /// <summary>
    /// This method loop on each row send in the data flow.
    /// Then it assign each entries variables with a locale one like this:  string shop = Row.strShop
    /// Where strShop is a column in the data flow
    /// </summary>
    /// <param name="Row">The row that is currently passing through the component</param>
    public override void Entrée0_ProcessInputRow(Entrée0Buffer Row)
    {
        // Links columns by variables
        string shop = Row.strShop;
        string libelle = Row.strLibelle;
        string numCompte = Row.strCompte;
        float priceF = (float) Row.montantF;
        DateTime dtDate =  Row.dtdate;


        // This ligne create a objet LigneFormat which is a string with one or 3 lignes.
        // The content of LigneFormat depend on the values of strShop, strlibelle, strCompte, montantF, the date and total number of operations; 
        LigneFormat strRow = new LigneFormat(shop, dtDate, numCompte, libelle, priceF, totalOperation);


        // These global value will increase after a row have been processed
        if(totalOperation == 0) { totalOperation += 2;}
        else { totalOperation += 1; }
        


        // Let to add a new row in the input data flow, then to write the value of LigneFormat in the input column ligneCAX3
        Sortie0Buffer.AddRow();
        Sortie0Buffer.ligneCAX3 = strRow.ToString();

    }

    public override void CreateNewOutputRows()
    {
        /*
          Add rows by calling the AddRow method on the member variable named "<Output Name>Buffer".
          For example, call MyOutputBuffer.AddRow() if your output was named "MyOutput".
        */

       
    }
}
