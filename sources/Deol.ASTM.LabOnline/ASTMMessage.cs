using System.Text;

namespace Deol.ASTM.LabOnline
{
    //Header Record
    //Number    Name                                    Values                  Comments                            Options
    //1         Record Type ID                          H                                                           M
    //2         Delimiter Definition                    |\^&                                                        M
    //3         Message Control ID                      -                       Not Used                            -
    //4         Access Password                         -                       Not Used                            -
    //5         Sender Name or ID                       LabOnline^1.0.0         Name^Version                        O
    //6         Sender Street Address                   -                       Not Used                            -
    //7         Not defined                             -                       Not Used                            -
    //8         Sender Telephone Number                 -                       Not Used                            -
    //9         Characteristics of Sender               -                       Not Used                            -
    //10        Receiver ID                             -                       Not Used                            -
    //11        Comment or Special Instructions         -                       Not Used                            -
    //12        Processing ID                           P                                                           M
    //13        Version No.                             E 1394-97               Version of the specification        O
    //14        Date and Time of Message                20091116104731          Date yyyyMMddHHmmss                 M

    //Terminator Record
    //Number    Name                                    Values                  Comments                            Options
    //1         Record Type ID                          L                                                           M
    //2         Sequence Number                         1                       Always 1                            M
    //3         Termination Code                        N                       Always "N" - Normal termination     M

    public class ASTMMessage
    {
        public ASTMList<ASTMPation> Pations { get; } = [];

        public override string ToString()
        {
            var sb = new StringBuilder();

            string header = $"H|\\^&||LabOnline^1.0.0|||||||P|E 1394-97|{DateTime.Now.ToString(Consts.FullDateFormat)}";

            sb.AppendLine(header);

            int pationNr = 0;

            foreach (var pation in Pations)
            {
                pationNr++;

                sb.AppendLine(pation.ToString(pationNr));

                if (pation.Comments != null)
                {
                    int commentNr = 0;

                    foreach (var comment in pation.Comments)
                    {
                        commentNr++;

                        sb.AppendLine(comment.ToString(commentNr));
                    }
                }

                int orderNr = 0;

                foreach (var order in pation.Orders)
                {
                    orderNr++;

                    sb.AppendLine(order.ToString(orderNr));

                    if (order.Comments != null)
                    {
                        int orderCommentNr = 0;

                        foreach (var comment in order.Comments)
                        {
                            orderCommentNr++;

                            sb.AppendLine(comment.ToString(orderCommentNr));
                        }
                    }

                    int resultNr = 0;

                    foreach(var result in order.Results)
                    {
                        resultNr++;

                        sb.AppendLine(result.ToString(resultNr));

                        if (result.Comments != null)
                        {
                            int resultCommentNr = 0;

                            foreach (var comment in result.Comments)
                            {
                                resultCommentNr++;

                                sb.AppendLine(comment.ToString(resultCommentNr));
                            }
                        }
                    }
                }
            }

            var end = "L|1|N";

            sb.Append(end);

            return sb.ToString();
        }
    }
}
