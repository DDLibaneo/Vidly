$(document).ready(function () {

    var viewModel = {
        movieIds: []
    };

    // apply typeahead to customer txtBox
    var customers = new Bloodhound({ // Bloodhound é a suggestion engine por trás do typeahead
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'), // nós passamos uma propriedade do Customer para o bloodhound tokenizar
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY', // O que o usuário digitar na txtBox será o valor da variável %QUERY
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({

        highlight: true
    },
        {
            name: 'customers',
            display: 'name',
            source: customers
        }).on("typeahead:select", function (e, customer) {

            viewModel.customerId = customer.id;
        });

    // apply typeahead to movie txtBox
    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY', // O que o usuário digitar na txtBox será o valor da variável %QUERY
            wildcard: '%QUERY'
        }
    });

    $('#movie').typeahead({

        highlight: true
    },
        {
            name: 'movies',
            display: 'name',
            source: movies
        }).on("typeahead:select", function (e, movie) {

            $("#movies").append("<li class='list-group-item'>" + movie.name + "</li>");

            $("#movie").typeahead("val", "");

            viewModel.movieIds.push(movie.id);
        });

    // Validation and Submit
    $.validator.addMethod("validCustomer", function () {
        return viewModel.customerId && viewModel.customerId !== 0;
    }, "Please select a valid customer.");

    $.validator.addMethod("isMovieSelected", function () {
        return viewModel.movieIds.length > 0;
    }, "Please select at least one movie.");

    $("#newRental").validate({
        submitHandler: function () {
            $.ajax({
                url: "/api/newRentals",
                method: "post",
                data: viewModel
            })
                .done(function () {
                    toastr.success("Rentals successfully recorded.");

                    $("#customer").typeahead("val", "");
                    $("#movie").typeahead("val", "");
                    $("#movies").typeahead.empty();
                    viewModel = { movieIds: [] };

                    validator.resetForm();
                })
                .fail(function () {
                    toastr.error("something unexpected happened");
                });

            return false;
        }
    });
});