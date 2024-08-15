using System.Text;

namespace Deol.ASTM.LabOnline
{
    //Pation Record
    //1     Record Type ID
    //2     Sequence Number
    //3     Practice Assigned Patiend ID
    //4     Laboratory Assigned Patient ID
    //5     Patient ID No. 3
    //6     Patient Name
    //7     Mother’s Maiden Name
    //8     Birthdate
    //9     Patient Sex
    //10    Patient Race
    //11    Patient Address
    //12    Reserved Field
    //13    Patient Telephone Number
    //14    Attending Physician ID.
    //15    Special Field 1 - Patient Age
    //16    Special Field 2 - Patient Type
    //17    Patient Height
    //18    Patient Weight
    //19    Diagnosis
    //20    Medication
    //21    Diet
    //22    Practice Field #1
    //23    Practice Field #2
    //24    Admission Date
    //25    Admission Status
    //26    Location
    //27    Nature of Diagnostic Code
    //28    Diagnostic Code
    //29    Patient Religion
    //30    Maritial Status
    //31    Isolation Status
    //32    Language
    //33    Hospital Service
    //34    Hospital Istitution
    //35    Dosage Category

    public class ASTMPation : ASTMRecord
    {
        public override char RecordType => 'P';

        public ASTMList<ASTMComment>? Comments { get; set; }

        public ASTMList<ASTMOrder> Orders { get; } = [];

        #region Protocol

        //3 Practice Assigned Patiend ID
        public string? PracticePatiendId { get; set; }

        //4 Laboratory Assigned Patient ID
        public string? LaboratoryPatiendId { get; set; }

        //6 Patient Name
        public ASTMPationName? Name { get; set; }

        private string? NameProtocol => Name?.ToString();

        //7 Mother’s Maiden Name
        public string? MotherMaidenName { get; set; }

        //8 Birthdate
        public DateTime? Birthdate { get; set; }

        public string? BirthdateProtocol => Birthdate?.ToString(Consts.ShortDateFormat);

        //9 Patient Sex
        public ASTMPationSex? Sex { get; set; }

        private string? SexProtocol => Sex?.ToString();

        //10 Patient Race
        public string? Race { get; set; }

        //13 Patient Telephone Number
        public string? PhoneNumber  { get; set; }

        private string? PhoneNumberProtocol => !string.IsNullOrEmpty(PhoneNumber) ? $"^{PhoneNumber}" : null;

        //14 Attending Physician ID
        public string? AttendingPhysicianId { get; set; }

        //15 Special Field 1 - Patient Age
        public ASTMPationAge? Age { get; set; }

        private string? AgeProtocol => Age?.ToString();

        //16 Special Field 2 - Patient Type
        public bool? ExternalPatient { get; set; }

        private string? ExternalPatientProtocol => 
            ExternalPatient != null ? 
            ExternalPatient.Value ? "1" : "0" 
            : null;

        //19 Diagnosis
        public ASTMList<ASTMClinicalData>? Diagnosis { get; set; }

        public string? DiagnosisProtocol => Diagnosis != null && Diagnosis.Count > 0 ? string.Join("\\", Diagnosis) : null;

        //26 Location
        public string? Location { get; set; }

        #endregion

        #region Get Fields

        public override string?[] GetFields() =>
        [
            /*3*/PracticePatiendId,
            /*4*/LaboratoryPatiendId,
            /*5*/null,
            /*6*/NameProtocol,
            /*7*/MotherMaidenName,
            /*8*/BirthdateProtocol,
            /*9*/SexProtocol,
            /*10*/Race,
            /*11*/null,
            /*12*/null,
            /*13*/PhoneNumberProtocol,
            /*14*/AttendingPhysicianId,
            /*15*/AgeProtocol,
            /*16*/ExternalPatientProtocol,
            /*17*/null,
            /*18*/null,
            /*19*/DiagnosisProtocol,
            /*20*/null,
            /*21*/null,
            /*22*/null,
            /*23*/null,
            /*24*/null,
            /*25*/null,
            /*26*/Location
            /*27*/ //null,
            /*28*/ //null,
            /*29*/ //null,
            /*30*/ //null,
            /*31*/ //null,
            /*32*/ //null,
            /*33*/ //null,
            /*34*/ //null,
            /*35*/ //null
        ];

        #endregion
    }

    public readonly struct ASTMPationName(string surname, string name)
    {
        public readonly string Name { get; } = name;
        public readonly string Surname { get; } = surname;

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
                return $"{Surname}^{Name}";

            return $"{Surname}";
        }
    }

    public enum ASTMPationSex
    {
        M = 0, //Male
        F = 1, //Female
        I = 2  //Indeterminate (used for Animals)
    }

    public enum ASTMPationAgeUnit
    {
        Years = 0,
        Days = 1,
        Months = 2
    }

    public readonly struct ASTMPationAge(int age, ASTMPationAgeUnit unit)
    {
        public readonly int Age { get; } = age;
        public readonly ASTMPationAgeUnit Unit { get; } = unit;

        public override string ToString()
        {
            return $"{Age}^{Unit}";
        }
    }

    public enum ASTMClinicalDataType
    {
        N = 0, //Number
        S = 1, //Free Text
        C = 2, //Coded Text
        D = 3  //DateTime
    }

    public readonly struct ASTMClinicalData(string code, ASTMClinicalDataType type, string value)
    {
        public readonly string Code { get; } = code;
        public readonly ASTMClinicalDataType Type { get; } = type;
        public readonly string Value { get; } = value;

        public override string ToString()
        {
            return $"{Code}^{Type}^{Value}";
        }
    }
}
