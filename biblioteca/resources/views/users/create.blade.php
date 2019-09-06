@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
<li class="nav-item">
    <a class="nav-link " href="#">Usuarios</a>
</li>
@endsection

@section('thead')
<th colspan="3" style="text-align:center">CREAR USUARIO</th>

@endsection

@section('tbody')
<tr>
    <td colspan="2">

        <form method="POST" action="{{ route('users.store') }}"  class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
                <div class="col-md-4 mb-3">
                    <label for="validationCustom01">Cod. de Usuario</label>
                    <input name="id" type="text" class="form-control" id="validationCustom01" placeholder="Ingrese Codigo de 3 digito" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4 mb-3">
                    <label for="validationCustomUsername">Email</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="inputGroupPrepend">@</span>
                        </div>
                        <input name="email" type="text" class="form-control" id="validationCustomUsername" placeholder="correo@micorreo.com"
                            aria-describedby="inputGroupPrepend" required>
                        <div class="invalid-feedback">
                            Please choose a username.
                        </div>
                    </div>
                </div>

                <div class="col-md-4 mb-3">
                    <label for="validationCustomUsername">Contrasenia</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="inputGroupPrepend">*</span>
                        </div>
                        <input name="pass" type="password" class="form-control" id="validationCustomUsername" placeholder="Ingrese Contrasenia"
                            aria-describedby="inputGroupPrepend" required>
                        <div class="invalid-feedback">
                            Please choose a username.
                        </div>
                    </div>
                </div>

            </div>
            <div class="form-row">
                <div class="col-md-4 mb-3">
                    <label for="validationCustom02">Nombre</label>
                    <input name="name" type="text" class="form-control" id="validationCustom02" placeholder="Ingrese Nombre"
                        required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-4 mb-3">
                    <label for="validationCustom01">Telefono</label>
                    <input name="phone" type="text" class="form-control" id="validationCustom01" placeholder="0000-1111" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>

                <div class="col-md-4 mb-3">
                    <label for="validationCustomUsername">Confirmar Contrasenia</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span name="pass2" class="input-group-text" id="inputGroupPrepend">*</span>
                        </div>
                        <input type="password" class="form-control" id="validationCustomUsername" placeholder="Confirmar Contrasenia"
                            aria-describedby="inputGroupPrepend" required>
                        <div class="invalid-feedback">
                            Please choose a username.
                        </div>
                    </div>
                </div>
            </div>
            <button class="btn btn-primary" type="submit">Crear Usuario</button>
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
