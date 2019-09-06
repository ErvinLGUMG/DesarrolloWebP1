@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
<li class="nav-item">
    <a class="nav-link " href="#">Usuarios</a>
</li>
@endsection

@section('thead')
<th colspan="3" style="text-align:center">CREAR EDITORIAL</th>

@endsection

@section('tbody')
<tr>
    <td colspan="2">

        <form method="POST" action="{{ route('editorials.store') }}" class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
                <div class="col-md-6">
                    <label for="validationCustom02">Nombre</label>
                    <input name="name" type="text" class="form-control" id="validationCustom02"
                        placeholder="Ingrese Nombre" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
                <div class="col-md-6">
                    <label for="validationCustom01">Pais</label>
                    <select id="inputState" name="pais" class="form-control">
                        @foreach ($paises as $value)
                            @foreach ($value as $pais)
                                <option>{{ $pais->CountryId }}</option>
                            @endforeach
                        @endforeach
                        {{-- {{ var_dump($data) }} --}}
                    </select>
                </div>
            </div>
            <br>
            <button class="btn btn-primary" type="submit">Crear Editorial</button>
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
