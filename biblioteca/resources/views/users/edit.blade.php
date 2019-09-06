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
<td style="text-align:center"> <a class="btn btn-success" href="{{ route('users.create') }}" role="button">Crear un usuario nuevo</a> </td>
</tr>
<th colspan="3" style="text-align:center">ACTUALIZAR LIBRO</th>
<tr>
    <td colspan="2">

    <form method="POST" action="{{route('users.update',$id)}}" class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
                <div class="col-md-4 mb-3">
                    <label for="validationCustom02">Email</label>
                    <input type="email" name="email" class="form-control" id="validationCustom02"
                        placeholder="Ingrese nuevo titulo" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4 mb-3">
                    <label for="validationCustom01">Nombre</label>
                    <input type="text" value=40 name="name" class="form-control" id="validationCustom01"
                        placeholder="Ingrese Id del documento que desea cambiar" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4 mb-3">
                        <label for="validationCustom01">Telefono</label>
                        <input type="number" value=40 name="phone" class="form-control" id="validationCustom01"
                            placeholder="Ingrese Id del documento que desea cambiar" required>
                        <div class="valid-feedback">
                            Looks good!
                        </div>
                    </div>
            </div>
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
