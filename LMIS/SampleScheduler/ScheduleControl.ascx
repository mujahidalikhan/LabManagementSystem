<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleControl.ascx.cs" Inherits="LMIS.SampleScheduler.ScheduleControl" %>
    <link rel="stylesheet" type="text/css" href="../Styles/fullcalendar.css" />
    <script language="javascript" type="text/javascript" src="../Scripts/overlib.js"></script>
    <script language="javascript" type="text/javascript" src="../Scripts/jquery.contextMenu.js"></script>

         <script type='text/javascript'>
             $(document).ready(function () {
                 $('#save_event').click(function (event) {
                     ajaxSaveEvent();
                 });
                 $('#add_event').click(function (event) {
                     //clear/reset form elements
                     //be careful in a full-blown app as I'm 
                     //selecting elements by type and could clear other elements on the page
                     $('select').attr('selectedIndex', 0);
                     $('[type=text]').val('');
                     //set id = 0 so when we update, we'll know the Event is a new record
                     $('#hdn_id').val(0);
                     //display modal dialog form
                     $("#dialog-modal").dialog({
                         height: 300,
                         width: 440,
                         modal: true
                     });
                 });
                 //load and render FullCalendar
                 loadCalendarEvents();
             });
             function loadCalendarEvents() {
                 /*Load and render FullCalendar
                 * FullCalendar v1.5.2 http://arshaw.com/fullcalendar/
                 --------------------------------------------------------------*/
                 

                 var parm = document.getElementById("<%= JobList.ClientID %>");
            // Get Dropdownlist selected item text
            var val = parm.options[parm.selectedIndex].value;
                 $('#calendar').fullCalendar({
                     header: {
                         left: 'prev,next today',
                         center: 'title',
                         right: 'month,agendaWeek,agendaDay'
                     },
                     editable: true,
                     events: { url: "../SampleScheduler/Events.aspx?qid=" + val, borderColor: "#70951D" },
                     eventDrop: ajaxUpdateDroppedEvent,
                     eventResize: ajaxUpdateResizedEvent,
                     loading: function (bool) {
                         //could display a 'loading' message
                     },
                    
                   
					
                  
                 });
             };

             /* Displays the modal dialog for Add and Edit of Events
             ---------------------------------------------------------------------------------------------------*/
             function showDialog() {
                 $("#dialog-modal").dialog({
                     height: 300,
                     width: 440,
                     modal: true
                 });
                 //Load Event from Database
                 ajaxGetEventForEdit($("#hdn_id").val());
             };

             /* Ajax method for retrieving information for a specific Event
             ---------------------------------------------------------------------------------------------------*/
             function ajaxGetTooltipInfo(id) {
             
                 $.ajax({
                     async: false,
                     type: "POST",
                     url: "../SampleScheduler/Events.aspx/GetEventData",
                     data: "{'id':'" + id + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: displayTooltip,
                     error: function (result) {
                         alert("Retrieving tooltip failed: " + result.status + ' ' + result.statusText);
                     }
                 });
             };

             /* Renders the tooltip information from the ajax method
             ---------------------------------------------------------------------------------------------------*/
             function displayTooltip(result) {
                 var start_date = new Date(result.d.StartDateAsString);
                 var end_date = new Date(result.d.EndDateAsString);
                 var tooltip = "Title: " + result.d.Title;
                 tooltip += "<br />Start: " + $.fullCalendar.formatDate(start_date, 'MM/dd/yyyy HH:mm:ss');
                 tooltip += "<br />End: " + $.fullCalendar.formatDate(end_date, 'MM/dd/yyyy HH:mm:ss');
                 tooltip += (result.d.AllDayEvent == false) ? "<br />All Day Event: No" : "<br />All Day Event: Yes";
                 tooltip += "<br />ID: " + result.d.CalendarKey;

                 return overlib(tooltip);
             };

             /* Generic Ajax failed message
             ---------------------------------------------------------------------------------------------------*/
             function AjaxFailed(result) {
                 alert(result.status + ' ' + result.statusText);
             };

             /* Ajax call to update the Event after a drag & drop operation
             If more form fields are added, need to modify the JSON string
             ---------------------------------------------------------------------------------------------------*/
             function ajaxUpdateDroppedEvent(event, dayDelta, minuteDelta, allDay, revertFunc) {
                 if (confirm("Are you sure you want to move this event?")) {
                    
                     $.ajax({
                         async: false,
                         type: "POST",
                         url: "../SampleScheduler/Events.aspx/UpdateEventData",
                         data: "{'id':'" + event.id + "','title':'','start':'" + $.fullCalendar.formatDate(event.start, 'MM/dd/yyyy HH:mm:ss') + "','end':'" + $.fullCalendar.formatDate(event.end, 'MM/dd/yyyy HH:mm:ss') + "','allDayEvent':'','backgroundColor':''}",
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         success: function (result) {
                             $('#calendar').fullCalendar('refetchEvents');
                         },
                         error: function (result) {
                             alert("Update event failed: " + result.status + ' ' + result.statusText);
                             revertFunc(); //FullCalendar: Moves the Event back to its original state.. Very handy!
                         }
                     });
                 }
                 else {
                     revertFunc(); //FullCalendar: Moves the Event back to its original state. Very handy!
                 };
             };

             /* Ajax call to update the Event after a Resize operation
             If more form fields are added, need to modify the JSON string
             ---------------------------------------------------------------------------------------------------*/
             function ajaxUpdateResizedEvent(event, dayDelta, minuteDelta, allDay, revertFunc) {
                 if (confirm("Are you sure you want to move this event?")) {
                   
                     $.ajax({
                         async: false,
                         type: "POST",
                         url: "../SampleScheduler/Events.aspx/UpdateEventData",
                         data: "{'id':'" + event.id + "','title':'','start':'" + $.fullCalendar.formatDate(event.start, 'MM/dd/yyyy HH:mm:ss') + "','end':'" + $.fullCalendar.formatDate(event.end, 'MM/dd/yyyy HH:mm:ss') + "','allDayEvent':'','backgroundColor':''}",
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         success: function (result) {
                             $('#calendar').fullCalendar('refetchEvents');
                         },
                         error: function (result) {
                             alert("Update event failed: " + result.status + ' ' + result.statusText);
                             revertFunc(); //FullCalendar: Moves the Event back to its original state.. Very handy!
                         }
                     });
                 }
                 else {
                     revertFunc(); //FullCalendar: Moves the Event back to its original state. Very handy!
                 };
             };

             /* Ajax method for retrieving Event record from database
             Set form elements with appropriate values
             ---------------------------------------------------------------------------------------------------*/
             function ajaxGetEventForEdit(id) {
                 //id of the FullCalendar element has a naming convention.
                 //a_id_[value of the id set in the JSON data] In this case, CalendarKey
                
                 $.ajax({
                     async: false,
                     type: "POST",
                     url: "../SampleScheduler/Events.aspx/GetEventData",
                     data: "{'id':'" + id + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (result) {
                         var dtStart = new Date(result.d.StartDateAsString);
                         var dtEnd = new Date(result.d.EndDateAsString);
                         $('#title').val(result.d.Title);
                         $('#start_date').val($.fullCalendar.formatDate(dtStart, 'MM/dd/yyyy'));
                         $('#start_hour').val($.fullCalendar.formatDate(dtStart, 'HH'));
                         $('#start_minute').val($.fullCalendar.formatDate(dtStart, 'mm'));

                         $('#end_date').val($.fullCalendar.formatDate(dtEnd, 'MM/dd/yyyy'));
                         $('#end_hour').val($.fullCalendar.formatDate(dtEnd, 'HH'));
                         $('#end_minute').val($.fullCalendar.formatDate(dtEnd, 'mm'));

                     },
                     error: AjaxFailed
                 });
             };

             /* Ajax method for persisting Event information to database
             ---------------------------------------------------------------------------------------------------*/
             function ajaxSaveEvent() {
                 var jsonData = "{";
                 jsonData += "'id':'" + $('#hdn_id').val() + "'";
                 jsonData += ",'title':'" + $('#title').val() + "'";
                 var start_date = new Date($('#start_date').val() + ' ' + $('#start_hour').val() + ':' + $('#start_minute').val());
                 var end_date = new Date($('#end_date').val() + ' ' + $('#end_hour').val() + ':' + $('#end_minute').val());

                 jsonData += ",'start':'" + $.fullCalendar.formatDate(start_date, 'MM/dd/yyyy HH:mm:ss') + "'";
                 jsonData += ",'end':'" + $.fullCalendar.formatDate(end_date, 'MM/dd/yyyy HH:mm:ss') + "'";
                 jsonData += ",'allDayEvent':'" + $('#all_day').val() + "'";

                 jsonData += "}";
                 $.ajax({
                     async: false,
                     type: "POST",
                     url: "../SampleScheduler/Events.aspx/UpdateEventData",
                     data: jsonData,
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (result) {
                         $("#dialog-modal").dialog('close');
                         $('#calendar').fullCalendar('refetchEvents');

                     },
                     error: function (result) {
                         alert("Update event failed: " + result.status + ' ' + result.statusText);
                     }
                 });
             };

             /* Ajax method for deleting Event record
             ---------------------------------------------------------------------------------------------------*/
             function ajaxDeleteEvent() {
                 if (!confirm("Are you sure you want to delete?"))
                     return;

                 $.ajax({
                     async: false,
                     type: "POST",
                     url: "../SampleScheduler/Events.aspx/DeleteEvent",
                     data: "{'id':'" + $('#hdn_id').val() + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (result) {
                         $('#calendar').fullCalendar('refetchEvents');
                     },
                     error: function (result) {
                         alert("Delete event failed: " + result.status + ' ' + result.statusText);
                     }
                 });
             };

             /* Function for adding days to Date object. - Not used, but could come in handy.
             ---------------------------------------------------------------------------------------------------*/
             Date.prototype.addDays = function (d) {
                 this.setDate(this.getDate() + d);
                 return this;
             };

             /* Function for adding minutes to Date object. - Not used, but could come in handy.
             ---------------------------------------------------------------------------------------------------*/
             Date.prototype.addMinutes = function (m) {
                 this.setMinutes(this.getMinutes() + m);
                 return this;
             };
             $(function () {
                 $("#start_date").datepicker();
             });
             $(function () {
                 $("#end_date").datepicker();
             });
    </script>
      

             
                        	<div class="simplebox">
                            	<div class="titleh"><h3>Schedul Test Master</h3></div>
                                <div class="body padding10">
                	
                                         	<div style="z-index: 680;" class="st-form-line">	
                                    	<span class="st-labeltext">Select Job:</span>	
                                         	    <asp:DropDownList  class="text ui-widget-content ui-corner-all" 
                                                    id="JobList" runat="server" 
                                                    onselectedindexchanged="JobList_SelectedIndexChanged" Width="350px" AutoPostBack="True"/>
                                    </div>
                                    

                        <!-- START CALENDAR -->
                        <div id='calendar'></div>
                        <!-- END CALENDAR -->
                        
                        
                        
                         <br />    <br />
                          &nbsp;<asp:Button ID="Button1" 
                                        runat="server" Text="Add Event"  CssClass="st-clear" onclick="Button1_Click" 
                                        Width="120px"/>
                                   
                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="List Event" CssClass="st-button" />
                                   
                    </div>
                       </div>
                       
                
                     
              
