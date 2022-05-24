$(document).ready(function () {
    $('#soundtrack')[0].volume = 0.1;

    $('#SendCrewNameBtn').on('click', function () {
        var curar = $('#CrewNamev2').val();
        $.post('/Sanitarios/ListaSanitarios',
            {
                CrewName: curar
            },
            function (data) {
                $('#tablaSanitarios').html(data);
            });
    });
    $('#CrewNameSearch').on('keyup', function () {
        ReloadSanitarioListByCrewName();
    });

    $('#CrewRankSearch').on('change', function () {
        ReloadPirateListByCrewRank();
    });
});

function ReloadPirateListByCrewName() {
    $('#CrewNameHidden').val($('#CrewNameSearch').val());
    $.post('/Piratas/ListaPiratas',
        {
            CrewName: $('#CrewNameHidden').val()
        },
        function (data) {
            $('#tablaPiratas').html(data);
            $('#CrewNameSearch').val($('#CrewNameHidden').val());

            $('#CrewNameSearch').on('keyup', function () {
                ReloadPirateListByCrewName();
            });

            $('#CrewNameSearch').focus();
        }
    );
}

function ReloadPirateListByCrewRank() {
    $('#CrewRankHidden').val($('#CrewRankSearch').val());
    $.post('/Piratas/ListaPiratas',
        {
            CrewRank: $('#CrewRankHidden').val()
        },
        function (data) {
            $('#tablaPiratas').html(data);
            $('#CrewRankSearch').val($('#CrewRankHidden').val());

            $('#CrewRankSearch').on('change', function () {
                ReloadPirateListByCrewRank();
            });

            $('#CrewRankSearch').focus();
        }
    );
}