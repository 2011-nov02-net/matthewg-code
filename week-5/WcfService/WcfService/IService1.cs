using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService {
    // attributes important in WCF:
    // ServiceContract:
    //      goes on an interface, to mark it as defining a SOAP "service"
    // OperationContract:
    //      goes on methods in a ServiceContract interface, to mark them as SOAP "operations" that service supports
    // DataContract:
    //      goes on classes/structs, to mark them as usable in the signatures of SOAP operations (and configure how it will be serialized in XML)
    // DataMember:
    //      goes on members of DataContract types, to opt them in for serialization and deserialization
    // FaultContract:
    //      goes on methods in a ServiceContract class implementation, to customize SOAP fault behavior


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1 {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
