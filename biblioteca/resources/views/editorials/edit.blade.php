@extends('layout')
@section('title', 'Libros')

@section('lateral')
<li class="nav-item">
    <a class="nav-link " href="#">Usuarios</a>
</li>
@endsection

@section('thead')
{{-- <th>Formulario</th> --}}
<th colspan="3" style="text-align:center">OPCIONES</th>
{{-- <th><a href="{{ route('users.create') }}">Crear USUARIO</a></th> --}}
@endsection

@section('tbody')
<tr>
    <td style="text-align:center"> <a class="btn btn-success" href="" role="button">Crear una editorial nuevo</a> </td>
</tr>
<th colspan="3" style="text-align:center">ACTUALIZAR EDITORIAL</th>
<tr>
    <td colspan="2">

        <form method="POST" action="{{route('editorials.update',$id)}}" class="needs-validation" novalidate>
            @csrf
            @method('PUT')
            <div class="form-row">
                <div class="col-md-12">
                    <label for="validationCustom03">Nombre</label>
                    <input name="name" type="text" class="form-control" id="validationCustom03" placeholder="Ingrese nuevo nombre" required>
                    <div class="invalid-feedback">
                        Please provide a valid city.
                    </div>
                </div>
            </div>
            <br>
            <button class="btn btn-primary" type="submit" style="align-items:center">Actualizar</button>
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
