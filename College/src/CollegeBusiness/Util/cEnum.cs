using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CollegeBusiness.Util
{
    public class cEnum
    {
        public enum TypeFile
        {
            EmailForgotPassword = 0,
            EmailContact = 1
        }

        public enum TypeMoney
        {
            [Description("R$")]
            BRL = 0,
            [Description("U$")]
            USD = 1
        }

        public enum statusModule
        {
            [Description("")]
            None = 0,
            [Description("<span class='label label-success'>LIBERADO</span>")]
            Open = 1,
            [Description("<span class='label label-default'>BLOQUEADO</span>")]
            Close = 2,
            [Description("<span class='label label-warning'>FINALIZADO</span>")]
            Finalized = 3
        }

        public enum statusResource
        {
            [Description("")]
            None = 0,
            [Description("<span class='label label-success'>LIBERADO</span>")]
            Open = 1,
            [Description("<span class='label label-default'>BLOQUEADO</span>")]
            Close = 2
        }

        public enum statusBlock
        {
            [Description("")]
            None = 0,
            [Description("<span class='label label-success'>LIBERADO</span>")]
            Open = 1,
            [Description("<span class='label label-default'>BLOQUEADO</span>")]
            Close = 2,
            [Description("<span class='label label-warning'>AGUARDANDO</span>")]
            Waiting = 3,
            [Description("<span class='label label-warning'>FINALIZADO</span>")]
            Finalized = 4

        }

        public enum statusExercise
        {
            [Description("")]
            None = 0,
            [Description("<span class='label label-warning'>AGUARDANDO SOLUÇÃO</span>")]
            Open = 1,
            [Description("<span class='label label-default'>BLOQUEADO</span>")]
            Close = 2,
            [Description("<span class='label label-warning'>EM CORREÇÃO</span>")]
            Correction = 3,
            [Description("<span class='label label-theme'>CORRIGIDO</span>")]
            Revised = 4
        }

        public enum statusTest
        {
            [Description("")]
            None = 0,
            [Description("<span class='label label-success'>AGUARDANDO SOLUÇÃO</span>")]
            Open = 1,
            [Description("<span class='label label-default'>BLOQUEADO</span>")]
            Close = 2,
            [Description("<span class='label label-theme'>EM ANDAMENTO</span>")]
            Progress = 3,
            [Description("<span class='label label-warning'>EM CORREÇÃO</span>")]
            Correction = 4,
            [Description("<span class='label label-success label-icon-only'><i class='fa fa-check-circle'></i></span>")]
            Okay = 5,
            [Description("<span class='label label-danger label-icon-only'><i class='fa fa-exclamation-circle'></i></span>")]
            Failing = 6
        }

        public enum CourseItemType
        {
            Module = 0,
            Block = 1,
            Resource = 2,
            Exercise = 3,
            Test = 4

        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
