function VacationTrackingModel() {
    self = this;
    var userId = 1;
    self.vacationsForManager = ko.observableArray();
    self.userPolicies = ko.observableArray();
    self.userRoles = ko.observableArray();
    self.isManager = ko.observable(false);
    self.isHR = ko.observable(false);
    self.isEmployee = ko.observable(false);
    //var holidays = ko.observableArray();
    self.GetUser = function () {

    }
    self.CreateUser = function () {
        var user = {
            FirstName: $("#firstname").val(),
            LastName: $("#lastname").val(),
            UserName: $("#username").val(),
            PassWord: $("#password").val(),
            Email: $("#email").val(),
            Experience: $("#experience").val(),
            Role: $(".user-Roles").val()
        }
        $.ajax({
            type: "POST",
            data:user,
            url: "api/User/CreateUser",
            success: function (data) {
                self.CloseCreateUserModal();
            },
            error: function (data) {
            }
        });
    }
    self.GetUserRoles = function () {
        $.ajax({
            type: "GET",
            url: "api/User/GetAllUserRoles",
            success: function (data) {
                for (var i in data) {
                    self.userRoles.push(data[i]);
                }
                
            },
            error: function (data) {
            }
        });
    }
    self.GetPolicies = function () {
        $.ajax({
            type: "GET",
            url: "api/Policy/GetAllPolicies",
            success: function (data) {
                for (var i in data) {
                    self.userPolicies.push(data[i]);
                }

            },
            error: function (data) {
            }
        });
    }

    self.GetAllVacationsRequests = function () {
        $.ajax({
            type: "GET",
            url: "api/Vacation/GetAllVacations",
            success: function (data) {
                var dataCalendar = $('#calendar').data('calendar').getDataSource();
                for (var i in data) {
                    var vacationRecordEvent = {
                        id: data[i].Id,
                        type: data[i].VacationType,
                        startDate: new Date(data[i].StartDate),
                        endDate: new Date(data[i].EndDate)
                    };
                    dataCalendar.push(vacationRecordEvent);
                    self.vacationsForManager.push(vacationRecordEvent);

                }
                $('#calendar').data('calendar').setDataSource(dataCalendar);
                console.log(data);
            },
            error: function (data) {
                $('#event-modal').modal('hide');
                alert("O_o troubles o_O");
            }
        });
    }
    self.OpenManagerModal = function () {
        $('#vacation-manager-modal').show();
    }
    self.CloseManagerModal = function () {
        $('#vacation-manager-modal').hide();
    }
    self.OpenCreateUserModal = function () {
        $('#create-user-modal').show();
    }
    self.CloseCreateUserModal = function () {
        $('#create-user-modal').hide();
    }
    self.ApproveVacation = function (vacation) {
        var model = {
            id: vacation.id,
            userId: 1,
            status: "Approved",
            type: vacation.type,
            startDate: moment(vacation.startDate).format('DD-MM-YYYY'),
            endDate: moment(vacation.endDate).format('DD-MM-YYYY')
        }
        $.ajax({
            type: "POST",
            data: model,
            url: "api/Manager/ApproveDeclineVacation",
            success: function (data) {
                console.log("Approve Request" + data);
                self.RemoveFromVacationsForManagerById(vacation.id);
            },
            error: function (data) {

            }
        });
    }
    self.RemoveFromVacationsForManagerById = function (vacationId) {
        self.vacationsForManager.remove(function (vacation) {
            return vacation.id == vacationId;
        });

    }
    self.DeclineVacation = function (vacation) {
        var model = {
            id: vacation.id,
            userId: 1,
            status: "Deny"
        }
        $.ajax({
            type: "POST",
            data: model,
            url: "api/Manager/ApproveDeclineVacation",
            success: function (data) {
                self.RemoveFromVacationsForManagerById(vacation.id);
            },
            error: function (data) {

            }
        });
    }
};
function editEvent(event) {
    $('#event-modal input[name="event-index"]').val(event ? event.id : '');
    $('#event-modal input[name="event-name"]').val(event ? event.name : '');
    $('#event-modal input[name="event-location"]').val(event ? event.type : '');
    $('#event-modal input[name="event-start-date"]').datepicker('update', event ? event.startDate : '');
    $('#event-modal input[name="event-end-date"]').datepicker('update', event ? event.endDate : '');
    $('#event-modal').modal();
}

function deleteEvent(event) {
    var dataSource = $('#calendar').data('calendar').getDataSource();

    for (var i in dataSource) {
        if (dataSource[i].id == event.id) {
            dataSource.splice(i, 1);
            break;
        }
    }

    $('#calendar').data('calendar').setDataSource(dataSource);
}

function saveEvent() {
    var event = {
        id: $('#event-modal input[name="event-index"]').val(),
        name: $("#username").val(),
        type: $(".policies").val(),
        startDate: $('#event-modal input[name="event-start-date"]').datepicker('getDate'),
        endDate: $('#event-modal input[name="event-end-date"]').datepicker('getDate')
    }
    var request = {
        VacationType: $(".policies").val(),
        StartDate: $('#event-modal input[name="event-start-date"]').datepicker({ dateFormat: 'dd-mm-yy' }).val(),
        EndDate: $('#event-modal input[name="event-end-date"]').datepicker({ dateFormat: 'dd-mm-yy' }).val(),
        Id: $('#event-modal input[name="event-index"]').val()
    };
    var path = "api/Vacation/CreateVacation";
    $.ajax({
        type: "Post",
        url: appPath + path,
        data: request,
        success: function (data) {
            console.log(data);
        },
        error: function (data) {
            $('#event-modal').modal('hide');
            alert("OO troubles");
        }

    })
    var dataSource = $('#calendar').data('calendar').getDataSource();

    if (event.id) {
        for (var i in dataSource) {
            if (dataSource[i].id == event.id) {
                dataSource[i].name = event.name;
                dataSource[i].type = event.type;
                dataSource[i].startDate = event.startDate;
                dataSource[i].endDate = event.endDate;
            }
        }
    }
    else {
        var newId = 0;
        for (var i in dataSource) {
            if (dataSource[i].id > newId) {
                newId = dataSource[i].id;
            }
        }

        newId++;
        event.id = newId;

        dataSource.push(event);
    }

     $('#calendar').data('calendar').setDataSource(dataSource);
    $('#event-modal').modal('hide');
    self.GetAllVacationsRequests();
}

$(function () {
    var currentYear = new Date().getFullYear();

    $('#calendar').calendar({
        enableContextMenu: true,
        enableRangeSelection: true,
        contextMenuItems: [
            {
                text: 'Update',
                click: editEvent
            },
            {
                text: 'Delete',
                click: deleteEvent
            }
        ],
        selectRange: function (e) {
            editEvent({ startDate: e.startDate, endDate: e.endDate });
        },
        mouseOnDay: function (e) {
            if (e.events.length > 0) {
                var content = '';

                for (var i in e.events) {
                    content += '<div class="event-tooltip-content">'
                        + '<div class="event-name" style="color:' + e.events[i].color + '">' + e.events[i].name + '</div>'
                        + '<div class="event-location">' + e.events[i].location + '</div>'
                        + '</div>';
                }

                $(e.element).popover({
                    trigger: 'manual',
                    container: 'body',
                    html: true,
                    content: content
                });

                $(e.element).popover('show');
            }
        },
        mouseOutDay: function (e) {
            if (e.events.length > 0) {
                $(e.element).popover('hide');
            }
        },
        dayContextMenu: function (e) {
            $(e.element).popover('hide');
        },
        dataSource: [
            {
                id: 0,
                name: 'Google I/O',
                location: 'San Francisco, CA',
                startDate: new Date(currentYear, 4, 28),
                endDate: new Date(currentYear, 4, 29)
            }
        ]
    });
    var vacationViewModel = new VacationTrackingModel();
    vacationViewModel.GetAllVacationsRequests();
    vacationViewModel.GetUserRoles();
    vacationViewModel.GetPolicies();
    $('#save-event').click(function () {
        saveEvent();
    });
});