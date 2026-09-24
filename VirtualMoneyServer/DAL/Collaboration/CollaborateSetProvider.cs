using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Tasks
{
    public class CollaborateSetProvider:IConnectionService
    {
        IQuery _collaborateQuery;


        public CollaborateSetProvider([FromKeyedServices("CollaborateSetQuery")] IQuery collaborateSetQuery)
        {
            _collaborateQuery = collaborateSetQuery;
        }





        public SqlConnection GetConnection()
        {

            return _collaborateQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _collaborateQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _collaborateQuery.GetQueryAction();
        }


        public void SetQueryAction()
        {

              _collaborateQuery.SetQueryAction("INSERT INTO Collaborate(parentId,childrenId) VALUES(@parentId,@childrenId)");

        }




    }
}
