@extends('layout')
@section('title', 'Autores')

@section('lateral')
<li class="nav-item">
    {{-- <a class="nav-link " href="#">Usuarios</a> --}}
</li>
@endsection

@section('thead')
{{-- <th>Formulario</th> --}}
<th colspan="3" style="text-align:center">OPCIONES</th>
{{-- <th><a href="{{ route('users.create') }}">Crear USUARIO</a></th> --}}
@endsection

@section('tbody')
<tr>
<td style="text-align:center"> <a class="btn btn-success" href="{{ route('authors.create') }}" role="button">Crear un autor nuevo</a> </td>
    <td style="text-align:center"> <a class="btn btn-primary" href="{{ route('authors.edit') }}" role="button">Actualizar un autor</a> </td>
</tr>
<th colspan="3" style="text-align:center">Eliminar Autor</th>
<tr>
    <td colspan="2">

        <form method="POST" action="{{ route('authors.eliminar') }}" class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
                <div class="col-md-4"></div>
                <div class="col-md-4" style="text-align:center">
                    <label for="validationCustom02">Cod. de Autor</label>
                    <input type="text" name="id" class="form-control" id="validationCustom02"
                        placeholder="Ingrese Codigo de Autor" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
            <br>
            <div style="text-align:center">
                <button class="btn btn-warning" type="submit" style="align-items:center">Eliminar</button>
            </div>
        </form>

        <script>
            // Example starter JavaScript for disabling form submissions if there are invalid fields
            (function () {
                'use strict';
                window.addEventListener('load', function () {
                    // Fetch all the forms we want to apply custom Bootstrap validation styles to
                    var forms = document.getElementsByClassName('needs-validation');
                    // Loop over them and prevent submission
                    var validation = Array.prototype.filter.call(forms, function (form) {
                        form.addEventListener('submit', function (event) {
                            if (form.checkValidity() === false) {
                                event.preventDefault();
                                event.stopPropagation();
                            }
                            form.classList.add('was-validated');
                        }, false);
                    });
                }, false);
            })();
        </script>
    </td>
</tr>
@endsection
