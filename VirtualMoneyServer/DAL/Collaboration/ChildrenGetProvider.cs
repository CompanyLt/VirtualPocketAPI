using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Collaboration
{
    public class ChildrenGetProvider:IConnectionService
    {
        IQuery _childrenQuery;


        public ChildrenGetProvider([FromKeyedServices("ChildrenGetQuery")] IQuery childrenGetQuery)
        {
            _childrenQuery = childrenGetQuery;
        }


        public SqlConnection GetConnection()
        {

            return _childrenQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _childrenQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _childrenQuery.GetQueryAction();
        }


        public void SetQueryAction()
        {

            //  _parentQuery.SetQueryAction("INSERT INTO ParentUser(name,password,mail,uniqueId,phoneNumber) VALUES(@name, @password, @mail, @uniqueId, @phoneNumber)");

        }




    }
}
