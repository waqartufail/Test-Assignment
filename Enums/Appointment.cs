using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Enums
{
    #region .json File Variable Name
    public enum Appointment
    {
        XPATH_APPOINTMENT_HEADING,
        XPATH_FACILITY,
        XPATH_HOSPITAL_ADMISSION,
        XPATH_MEDICINE,
        XPATH_MEDICAID,
        XPATH_NONE,
        XPATH_VISIT_DATE,
        XPATH_COMMENTS,
        XPATH_BOOK_APPOINTMENT,
        XPATH_APPOINTMENT_CONFIRMATION,
        XPATH_MENU,
        XPATH_HISTORY,
        XPATH_SUBMITTED_FACILITY
    }
    #endregion

    public static class AppointmentExtensions
    {
        #region IDENTIFIERS
        private static readonly Dictionary<Appointment, string> _pageVariables = new Dictionary<Appointment, string>
        {
            {Appointment.XPATH_APPOINTMENT_HEADING, "(//h2)" },
            {Appointment.XPATH_FACILITY,"(//select[@id='combo_facility'])" },
            {Appointment.XPATH_HOSPITAL_ADMISSION,"(//input[@id='chk_hospotal_readmission'])" },
            {Appointment.XPATH_MEDICINE,"(//input[@id='radio_program_medicare'])" },
            {Appointment.XPATH_MEDICAID,"(//input[@id='radio_program_medicaid'])" },
            {Appointment.XPATH_NONE,"(//input[@id='radio_program_none'])" },
            {Appointment.XPATH_VISIT_DATE,"(//input[@id='txt_visit_date'])" },
            {Appointment.XPATH_COMMENTS,"(//textarea[@id='txt_comment'])" },
            {Appointment.XPATH_BOOK_APPOINTMENT,"(//button[@id='btn-book-appointment'])" },
            {Appointment.XPATH_APPOINTMENT_CONFIRMATION,"(//h2)" },
            {Appointment.XPATH_MENU, "(//a[@id='menu-toggle'])" },
            {Appointment.XPATH_HISTORY, "(//li//a[contains(@href,'history')])" },
            {Appointment.XPATH_SUBMITTED_FACILITY, "(//p[@id='facility'])" }
        };
        #endregion

        #region Methods
        public static string GetValue(this Appointment appointment)
        {
            return _pageVariables[appointment];
        }

        public static string GetPageVariables(this Appointment appointment)
        {
            return _pageVariables[appointment];
        }
        #endregion
    }
}
