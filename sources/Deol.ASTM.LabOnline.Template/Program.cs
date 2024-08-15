namespace Deol.ASTM.LabOnline.Template
{
    internal class Program
    {
        static void Main()
        {
            var message1 = new ASTMMessage()
            {
                //min data
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789"
                    },
                }
            };

            var message2 = new ASTMMessage()
            {
                //standart data
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",
                        Name = new ASTMPationName("Иванов", "Иван"),
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.M,
                        ExternalPatient = false
                    }
                }
            };

            var message3 = new ASTMMessage()
            {
                //full data
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",
                        Name = new ASTMPationName("Иванова", "Иванка"),
                        MotherMaidenName = "Петрова",
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.F,
                        Race = "C",
                        PhoneNumber = "+79991235555",
                        AttendingPhysicianId = "123",
                        Age = new ASTMPationAge(24, ASTMPationAgeUnit.Years),
                        ExternalPatient = false,
                        Diagnosis =
                        [
                            new ASTMClinicalData("Week", ASTMClinicalDataType.N, "25"),
                            new ASTMClinicalData("Diagnosis", ASTMClinicalDataType.S, "Diabetes"),
                            new ASTMClinicalData("Diuresis", ASTMClinicalDataType.N, "348"),
                        ],
                        Location = "Moscow"
                    }
                }
            };

            var message4 = new ASTMMessage()
            {
                //min data + pation comment
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",

                        Comments =
                        [
                            new ASTMComment()
                            {
                                Code = "CK",
                                Text =
                                {
                                    "DeviceCode",
                                    "Check-In date and time (YYYYMMDDHH24MISS)"
                                }
                            }
                        ]
                    },
                }
            };

            var message5 = new ASTMMessage()
            {
                //standart data + pation comment
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",
                        Name = new ASTMPationName("Иванов", "Иван"),
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.M,
                        ExternalPatient = false,
                        
                        Comments =
                        [
                            new ASTMComment()
                            {
                                Code = "CK",
                                Text =
                                {
                                    "DeviceCode",
                                    "Check-In date and time (YYYYMMDDHH24MISS)"
                                }
                            }
                        ]
                    }
                }
            };

            var message6 = new ASTMMessage()
            {
                //min data + order
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "1234567",
                                TestIds = [ ASTMTestId.FixedValue ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now
                            }
                        }
                    },
                }
            };

            var message7 = new ASTMMessage()
            {
                //pation + comment + order (standart data)
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",
                        Name = new ASTMPationName("Иванов", "Иван"),
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.M,
                        ExternalPatient = false,

                        Comments =
                        [
                            new ASTMComment()
                            {
                                Code = "CK",
                                Text =
                                {
                                    "DeviceCode",
                                    "Check-In date and time (YYYYMMDDHH24MISS)"
                                }
                            }
                        ],

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "1234567",
                                SamplePosition = new ASTMSamplePosition("102", 5),
                                TestIds = [ ASTMTestId.FixedValue ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now,
                                ActionCode = ASTMActionCode.N,
                                BiomaterialCode = "SERUM",
                                ReportTypes = "F"
                            }
                        }
                    },
                }
            };

            var message8 = new ASTMMessage()
            {
                //pation + comment + order + results (standart data)
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "123456789",
                        LaboratoryPatiendId = "123456789",
                        Name = new ASTMPationName("Иванов", "Иван"),
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.M,
                        ExternalPatient = false,

                        Comments =
                        [
                            new ASTMComment()
                            {
                                Code = "CK",
                                Text =
                                {
                                    "Text"
                                }
                            }
                        ],

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "1234567",
                                SamplePosition = new ASTMSamplePosition("102", 5),
                                TestIds = [ ASTMTestId.FixedValue ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now,
                                ActionCode = ASTMActionCode.N,
                                BiomaterialCode = "SERUM",
                                ReportTypes = "F",

                                Comments =
                                [
                                    new ASTMComment()
                                    {
                                        Code = "CommentCode",
                                        Text =
                                        {
                                            "Text1",
                                            "Text2",
                                            "Text3"
                                        }
                                    }
                                ],

                                Results =
                                {
                                    new ASTMResult()
                                    {
                                        TestId = new ASTMTestId()
                                        {
                                            TestCode = "testCode1",
                                            AnalysisCode = "analysisCode1"
                                        },
                                        Value = "5",
                                        Units = "nmol/L",
                                        ReferenceRanges = "1-10",
                                        Normality = ASTMResultNormality.Normal,
                                        NatureOfAbnormalityTesting = "H",
                                        ResultStatus = ASTMResultStatus.F,
                                        OperatorId = new ASTMOperatorId("User"),
                                        StartDate = DateTime.Now,
                                        ValidationDate = DateTime.Now,
                                        CompletedDate = DateTime.Now,
                                        InstrumentId = new ASTMInstrumentId(ASTMInstrumentActionType.Normal, "instrumentCode")
                                    },
                                    new ASTMResult()
                                    {
                                        TestId = new ASTMTestId()
                                        {
                                            TestCode = "testCode2"
                                        },
                                        Value = "4",
                                        Units = "nmol/L",
                                        ReferenceRanges = "1-10",
                                        Normality = ASTMResultNormality.Normal,
                                        NatureOfAbnormalityTesting = "H",
                                        ResultStatus = ASTMResultStatus.F,
                                        OperatorId = new ASTMOperatorId("", "Manager", ""),
                                        StartDate = DateTime.Now,
                                        ValidationDate = DateTime.Now,
                                        CompletedDate = DateTime.Now,
                                        InstrumentId = new ASTMInstrumentId(ASTMInstrumentActionType.Edit, "123")
                                        {
                                            SerialNumber = "SN1",
                                            BayNumber = "BN1"
                                        }
                                    }
                                }
                            }
                        }
                    },
                }
            };

            var message9 = new ASTMMessage()
            {
                //test 5000044439
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "5000044439",
                        LaboratoryPatiendId = "5000044439",
                        Name = new ASTMPationName("Тест", "Тест Тест"),
                        Birthdate = new DateTime(2000, 01, 01),
                        Sex = ASTMPationSex.M,
                        ExternalPatient = false,

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "5000044439",
                                TestIds = [ ASTMTestId.FixedValue ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now,
                                BiomaterialCode = "SERUM",
                                ReportTypes = "F",

                                Results =
                                {
                                    new ASTMResult()
                                    {
                                        TestId = new ASTMTestId()
                                        {
                                            AnalysisCode = "T3-FREE"
                                        },
                                        Value = "3.3",
                                        Units = "pmol/L",
                                        ResultStatus = ASTMResultStatus.F,
                                        OperatorId = new ASTMOperatorId("Val.Autom."),
                                        StartDate = DateTime.Now,
                                        CompletedDate = DateTime.Now,
                                        InstrumentId = new ASTMInstrumentId(ASTMInstrumentActionType.Normal, "D01-ALi-RS")
                                    }
                                }
                            }
                        }
                    },
                }
            };

            var message10 = new ASTMMessage()
            {
                //test 5000044427
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "5000044427",
                        LaboratoryPatiendId = "5000044427",

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "5000044427",
                                TestIds = [ ASTMTestId.FixedValue ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now,

                                Results =
                                {
                                    new ASTMResult()
                                    {
                                        TestId = new ASTMTestId()
                                        {
                                            AnalysisCode = "T3-FREE"
                                        },
                                        Value = "3.3",
                                        ResultStatus = ASTMResultStatus.F,
                                        OperatorId = new ASTMOperatorId("Val.Autom."),
                                        InstrumentId = new ASTMInstrumentId(ASTMInstrumentActionType.Normal, "D01-ALi-RS")
                                    }
                                }
                            }
                        }
                    },
                }
            };

            var message11 = new ASTMMessage()
            {
                Pations =
                {
                    new ASTMPation()
                    {
                        PracticePatiendId = "5000000000",
                        LaboratoryPatiendId = "5000000000",

                        Orders =
                        {
                            new ASTMOrder()
                            {
                                SampleId = "5000000000",
                                TestIds = 
                                [ 
                                    new ASTMTestId() { TestCode = "test1", AnalysisCode  = "test1" },
                                    new ASTMTestId() { TestCode = "test2", AnalysisCode  = "test2" },
                                    new ASTMTestId() { TestCode = "test3", AnalysisCode  = "test3" },
                                ],
                                Priority = ASTMPriority.R,
                                RequestDate = DateTime.Now
                            }
                        }
                    },
                }
            };

            Print("min data", message1);
            Print("standart data", message2);
            Print("full data", message3);
            Print("min data + pation comment", message4);
            Print("standart data + pation comment", message5);
            Print("min data + order", message6);
            Print("pation + comment + order (standart data)", message7);
            Print("pation + comment + order + results (standart data)", message8);
            Print("test 5000044439", message9);
            Print("test 5000044427", message10);
            Print("test 5000000000", message11);
        }

        static void Print(string header, ASTMMessage message)
        {
            Console.WriteLine(header);
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
