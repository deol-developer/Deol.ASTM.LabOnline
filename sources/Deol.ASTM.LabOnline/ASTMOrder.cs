namespace Deol.ASTM.LabOnline
{
    public class ASTMOrder : ASTMRecord
    {
        //1     Record Type ID
        //2     Sequence Number
        //3     Specimen ID
        //4     Instrument Specimen ID
        //5     Universal Test ID
        //6     Priority
        //7     Requested/Ordered data and time
        //8     Specimen Collection Date and Time
        //9     Collection End Time
        //10    Collection Volume
        //11    Collector ID
        //12    Action Code
        //13    Danger Code
        //14    Relevant Clinical Information
        //15    Date/Time Specimen Received
        //16    Specimen Descriptor
        //17    Ordering Physician
        //18    Physician’s Telephone Number
        //19    User Field No. 1
        //20    User Field No. 2
        //21    Laboratory Field No. 1
        //22    Laboratory Field No. 2
        //23    Date/Time Result Reported or Last Modified
        //24    Instrument Charge to Computer System
        //25    Instrument Section ID
        //26    Report Types
        //27    Reserved Field
        //28    Location of Ward of Specimen Collection
        //29    Nosocomial Infection Flag
        //30    Specimen Service
        //31    Specimen Institution

        public override char RecordType => 'O';

        public ASTMList<ASTMComment>? Comments { get; set; }

        public ASTMList<ASTMResult> Results { get; } = [];

        #region Protocol

        //3 Specimen ID
        public string? SampleId { get; set; }

        //4 Instrument Specimen ID
        public ASTMSamplePosition? SamplePosition { get; set; }

        private string? SamplePositionProtocol => SamplePosition?.ToString();

        //5 Universal Test ID
        public ASTMList<ASTMTestId>? TestIds { get; set; }

        private string? TestIdsProtocol => TestIds != null && TestIds.Count > 0 ? string.Join("\\", TestIds) : null;

        //6 Priority
        public ASTMPriority? Priority { get; set; }

        public string? PriorityProtocol => Priority?.ToString();

        //7 Requested/Ordered data and time
        public DateTime? RequestDate { get; set; }

        private string? RequestDateProtocol => RequestDate?.ToString(Consts.FullDateFormat);

        //8 Specimen Collection Date and Time
        public DateTime? SampleDrawDate { get; set; }

        private string? SampleDrawDateProtocol => SampleDrawDate?.ToString(Consts.FullDateFormat);

        //12 Action Code
        public ASTMActionCode? ActionCode { get; set; }

        private string? ActionCodeProtocol => ActionCode?.ToString();

        //16 Specimen Descriptor
        public string? BiomaterialCode { get; set; }

        //19 User Field No. 1
        public string? UserField1 { get; set; }

        //20 User Field No. 2
        public string? UserField2 { get; set; }

        //21 Laboratory Field No. 1
        public string? LaboratoryField1 { get; set; }

        //22 Laboratory Field No. 2
        public string? LaboratoryField2 { get; set; }

        //26 Report Types
        public string? ReportTypes { get; set; }

        //31 Specimen Institution
        public string? SpecimenInstitution { get; set; }

        #endregion

        #region Get Fields

        public override string?[] GetFields() =>
        [
            /*3*/SampleId,
            /*4*/SamplePositionProtocol,
            /*5*/TestIdsProtocol,
            /*6*/PriorityProtocol,
            /*7*/RequestDateProtocol,
            /*8*/SampleDrawDateProtocol,
            /*9*/null,
            /*10*/null,
            /*11*/null,
            /*12*/ActionCodeProtocol,
            /*13*/null,
            /*14*/null,
            /*15*/null,
            /*16*/BiomaterialCode,
            /*17*/null,
            /*18*/null,
            /*19*/UserField1,
            /*20*/UserField2,
            /*21*/LaboratoryField1,
            /*22*/LaboratoryField2,
            /*23*/null,
            /*24*/null,
            /*25*/null,
            /*26*/ReportTypes,
            /*27*/null,
            /*28*/null,
            /*29*/null,
            /*30*/null,
            /*31*/SpecimenInstitution
        ];

        #endregion
    }

    public readonly struct ASTMSamplePosition(string rackId, int position)
    {
        public readonly string RackId { get; } = rackId;

        public readonly int Position { get; } = position;

        public override string ToString()
        {
            return $"^{RackId}^{Position}";
        }
    }

    public class ASTMTestId(bool isFixed) : ASTMFieldSet
    {
        private readonly bool _isFixed = isFixed;

        public bool IsFixed => _isFixed;

        private static readonly ASTMTestId _fixedValue = new(true);

        public static ASTMTestId FixedValue => _fixedValue;


        public override char Separator => '^';

        public string? TestCode { get; set; }
        public string? AnalysisCode { get; set; }
        public string? Dilution { get; set; }
        public string? ReagentLot { get; set; }
        public string? ReagentSerialNr { get; set; }
        public string? ControlLotNr { get; set; } 
        public string? ResultType { get; set; }
        public string? ResultGUID { get; set; }
        public string? ControlGUID1 { get; set; }
        public string? ControlGUID2 { get; set; }
        public string? ControlGUID3 { get; set; }
        public string? ControlGUID4 { get; set; }
        public string? ControlGUID5 { get; set; }
        public string? AWOSID { get; set; }
        public string? BatchId { get; set; }

        public ASTMTestId() : this(false) {}

        public override string?[] GetFields() =>
        [
            TestCode,
            AnalysisCode,
            Dilution,
            ReagentLot,
            ReagentSerialNr,
            ControlLotNr,
            ResultType,
            ResultGUID,
            ControlGUID1,
            ControlGUID2,
            ControlGUID3,
            ControlGUID4,
            ControlGUID5,
            AWOSID,
            BatchId
        ];

        public override string ToString()
        {
            if (_isFixed)
                return "^^^*****";

            return $"^^^{base.ToString()}";
        }
    }

    public enum ASTMPriority
    {
        R = 0, //Routine
        S = 1  //Stat
    }

    public enum ASTMActionCode
    {
        N = 0, //Create a new test order
        R = 1, //Request a rerun for a test
        C = 2, //Cancel a test order
        A = 3, //Add a test to a known specimen
        Q = 4  //For quality control
    }
}
