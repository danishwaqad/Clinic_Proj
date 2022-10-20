var RegistrationForm = angular.module("RegistrationForm", []);
RegistrationForm.controller("Home", function ($scope, $http, $window) {
    $scope.Notification = function (Type, Heading, Test) {
        //info, warning, success, error
        $.toast({
            heading: Heading,
            text: Test,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: Type,
            hideAfter: 3500,
            stack: 6
        });
    };

!function ($) {
    "use strict";

    var CalendarApp = function () {
        this.$body = $("body")
        this.$calendar = $('#calendar'),
            this.$event = ('#calendar-events div.calendar-events'),
            this.$categoryForm = $('#add-new-event form'),
            this.$extEvents = $('#calendar-events'),
            this.$modal = $('#my-event'),
            this.$saveCategoryBtn = $('.save-category'),
            this.$calendarObj = null
    };
    //================Insert Dr Data===================================
    $scope.SaveData = function (title, start, end, allDay, className) {
        var displayReq = {
            method: 'POST',
            url: '/Calender/Add_CalenderRecrd',
            data: {
                title: title,
                start: start,
                end: end,
                allDay: allDay,
                className: className
            }
        }
        $http(displayReq).then(function (Return) {

            if (Return.data == "Inserted") {
                $scope.Notification('success', 'Operation Completed', 'Insert Event');
                $scope.On_Clear();
            }
            else {
                $scope.Notification('error', 'Error Code CU1002', 'Please Contact to Admin');
            }
        }, function myError(Return) {
            $scope.Notification('error', 'Error Code CU0002', 'Please Contact to Admin');
            $scope.On_Clear();
        });
    };
    //function _Add(title, start, end, allDay, className) {

    //    fetch('/Calender/Add_CalenderRecrd', {
    //        method: 'POST',
    //        body: JSON.stringify({
    //            title: title,
    //            start: start,
    //            end: end,
    //            allDay: allDay,
    //            className: className,
    //        }),
    //        headers: {
    //            'Accept': 'application/json',
    //            'Content-Type': 'application/json'
    //        }
    //    })
    //        .then(response => response.json())
    //    .then (data => {
    //        alert(data);
    //        })
    //        .catch(response => {
    //            alert(response);
    //        });
    //};

    //function _Get() {
    //    fetch('/Calender/Get_data', {
    //        method: 'POST',
    //        headers: {
    //            'Accept': 'application/json',
    //            'Content-Type': 'application/json'
    //        }
    //    })
    //        .then(response => response.json())
    //        .then(data => {
    //            alert(data);
    //            return data;
    //        })
    //        .catch(response => {

    //        });
    //  };
    //==============Display Events===================
    $scope.GetDisplayData = function () {
        var displayReq = {
            method: "POST",
            url: "/Calender/Get_data",
            data: {
            }
        }
        $http(displayReq).then(function (Return) {

            alert('Running');

            $this.$calendarObj.fullCalendar('renderEvent', {
                title: 'Running',
                start: new Date(),
                end: new Date(),
                allDay: false,
                className: 'bg-danger'
            }, true);
            $this.$modal.modal('hide');


            //var dt = angular.fromJson(Return.data);

            //for (var i = 0; i < dt.length; i++) {

            //    $this.$calendarObj.fullCalendar('renderEvent', {
            //        title: dt[i].Title,
            //        start: new Date(dt[i].StartDate),
            //        end: new Date(dt[i].EndDate),
            //        allDay: false,
            //        className: dt[i].ClassName
            //    }, true);
            //    //$this.$modal.modal('hide');

            //}

        }, function myError(Return) {
            $scope.Notification('error', 'Error Code LC0001', Return.data);
        });
    };

    function _Running() {
        //alert(new Date());
        //$this123.$calendarObj.fullCalendar('renderEvent', {
        //    title: 'Running',
        //    start: new Date(),
        //    allDay: false,
        //    className: 'bg-danger'
        //}, true);
    };

    /* on drop */
    CalendarApp.prototype.onDrop = function (eventObj, date) {
        var $this = this;
        // retrieve the dropped element's stored Event Object
        var originalEventObject = eventObj.data('eventObject');
        var $categoryClass = eventObj.attr('data-class');
        // we need to copy it, so that multiple events don't have a reference to the same object
        var copiedEventObject = $.extend({}, originalEventObject);
        // assign it the date that was reported
        copiedEventObject.start = date;
        if ($categoryClass)
            copiedEventObject['className'] = [$categoryClass];
        // render the event on the calendar
        $this.$calendar.fullCalendar('renderEvent', copiedEventObject, true);
        // is the "remove after drop" checkbox checked?
        if ($('#drop-remove').is(':checked')) {
            // if so, remove the element from the "Draggable Events" list
            eventObj.remove();
        }
    },
        /* on click on event */
        CalendarApp.prototype.onEventClick = function (calEvent, jsEvent, view) {
            var $this = this;
            var form = $("<form></form>");
            form.append("<label>Change event name</label>");
            form.append("<div class='input-group'><input class='form-control' type=text value='" + calEvent.title + "' /><span class='input-group-btn'><button type='submit' class='btn btn-success waves-effect waves-light'><i class='fa fa-check'></i> Save</button></span></div>");
            $this.$modal.modal({
                backdrop: 'static'
            });
            $this.$modal.find('.delete-event').show().end().find('.save-event').hide().end().find('.modal-body').empty().prepend(form).end().find('.delete-event').unbind('click').click(function () {
                $this.$calendarObj.fullCalendar('removeEvents', function (ev) {
                    return (ev._id == calEvent._id);
                });
                $this.$modal.modal('hide');
            });
            $this.$modal.find('form').on('submit', function () {
                calEvent.title = form.find("input[type=text]").val();
                $this.$calendarObj.fullCalendar('updateEvent', calEvent);
                $this.$modal.modal('hide');
                return false;
            });
        },
        /* on select */
        CalendarApp.prototype.onSelect = function (start, end, allDay) {
            var $this = this;
            $this.$modal.modal({
                backdrop: 'static'
            });
            var form = $("<form></form>");
            form.append("<div class='row'></div>");
            form.find(".row")
                .append("<div class='col-md-6'><div class='form-group'><label class='control-label'>Event Name</label><input class='form-control' placeholder='Insert Event Name' type='text' name='title'/></div></div>")
                .append("<div class='col-md-6'><div class='form-group'><label class='control-label'>Category</label><select class='form-control' name='category'></select></div></div>")
                .find("select[name='category']")
                .append("<option value='bg-danger'>Danger</option>")
                .append("<option value='bg-success'>Success</option>")
                .append("<option value='bg-purple'>Purple</option>")
                .append("<option value='bg-primary'>Primary</option>")
                .append("<option value='bg-pink'>Pink</option>")
                .append("<option value='bg-info'>Info</option>")
                .append("<option value='bg-warning'>Warning</option></div></div>");
            $this.$modal.find('.delete-event').hide().end().find('.save-event').show().end().find('.modal-body').empty().prepend(form).end().find('.save-event').unbind('click').click(function () {
                form.submit();
            });
            $this.$modal.find('form').on('submit', function () {
                var title = form.find("input[name='title']").val();
                var beginning = form.find("input[name='beginning']").val();
                var ending = form.find("input[name='ending']").val();
                var categoryClass = form.find("select[name='category'] option:checked").val();
                if (title !== null && title.length != 0) {
                    $scope.SaveData(title, start, end, allDay, categoryClass);
                    $this.$calendarObj.fullCalendar('renderEvent', {
                        title: title,
                        start: start,
                        end: end,
                        allDay: false,
                        className: categoryClass
                    }, true);
                    $this.$modal.modal('hide');
                }
                else {
                    alert('You have to give a title to your event');
                }
                return false;

            });
            $this.$calendarObj.fullCalendar('unselect');
        },
        CalendarApp.prototype.enableDrag = function () {
            //init events
            $(this.$event).each(function () {
                // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                // it doesn't need to have a start or end
                var eventObject = {
                    title: $.trim($(this).text()) // use the element's text as the event title
                };
                // store the Event Object in the DOM element so we can get to it later
                $(this).data('eventObject', eventObject);
                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });
            });
        }

    /* Initializing */
    CalendarApp.prototype.init = function () {

        this.enableDrag();
        /*  Initialize the calendar  */
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();
        var form = '';
        var today = new Date($.now());


        var defaultEvents = [{
            title: 'Released Ample Admin!',
            start: new Date($.now() + 506800000),
            className: 'bg-info'
        }, {
            title: 'This is today check date',
            start: today,
            end: today,
            className: 'bg-danger'
        }, {
            title: 'This is your birthday',
            start: new Date($.now() + 848000000),
            className: 'bg-info'
        }, {
            title: 'your meeting with john',
            start: new Date($.now() - 1099000000),
            end: new Date($.now() - 919000000),
            className: 'bg-warning'
        }, {
            title: 'your meeting with john',
            start: new Date($.now() - 1199000000),
            end: new Date($.now() - 1199000000),
            className: 'bg-purple'
        }, {
            title: 'your meeting with john',
            start: new Date($.now() - 399000000),
            end: new Date($.now() - 219000000),
            className: 'bg-info'
        },
        {
            title: 'Hanns birthday',
            start: new Date($.now() + 868000000),
            className: 'bg-danger'
        }, {
            title: 'Like it?',
            start: new Date($.now() + 348000000),
            className: 'bg-success'
        }];

        var $this = this;
        $this.$calendarObj = $this.$calendar.fullCalendar({
            slotDuration: '00:15:00', /* If we want to split day time each 15minutes */
            minTime: '08:00:00',
            maxTime: '19:00:00',
            defaultView: 'month',
            handleWindowResize: true,

            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            events: defaultEvents,
            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar !!!
            eventLimit: true, // allow "more" link when too many events
            selectable: true,
            drop: function (date) { $this.onDrop($(this), date); },
            select: function (start, end, allDay) { $this.onSelect(start, end, allDay); },
            eventClick: function (calEvent, jsEvent, view) { $this.onEventClick(calEvent, jsEvent, view); }

        });

        //on new event
        this.$saveCategoryBtn.on('click', function () {
            var categoryName = $this.$categoryForm.find("input[name='category-name']").val();
            var categoryColor = $this.$categoryForm.find("select[name='category-color']").val();
            if (categoryName !== null && categoryName.length != 0) {
                $this.$extEvents.append('<div class="calendar-events" data-class="bg-' + categoryColor + '" style="position: relative;"><i class="fa fa-circle text-' + categoryColor + '"></i>' + categoryName + '</div>')
                $this.enableDrag();
            }

        });

        _Running();
    },

        //init CalendarApp
        $.CalendarApp = new CalendarApp, $.CalendarApp.Constructor = CalendarApp

}(window.jQuery),

    //initializing CalendarApp
    function ($) {
        "use strict";
        $.CalendarApp.init()
        }(window.jQuery);
});