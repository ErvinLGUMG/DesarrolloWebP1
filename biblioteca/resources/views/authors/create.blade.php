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
    <td style="text-align:center"> <a class="btn btn-success" href="#" role="button">Crear un libro nuevo</a> </td>
    <td style="text-align:center"> <a class="btn btn-danger" href="#" role="button">Eliminar un libro</a> </td>

</tr>
<th colspan="3" style="text-align:center">ACTUALIZAR LIBRO</th>
<tr>
    <td colspan="2">

        <form method="POST" action="{{ route('authors.store') }}" class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
              <div class="col-md-4 mb-3">
                <label for="validationCustom02">Autor</label>
                <input type="text" name="author" class="form-control" id="validationCustom02" placeholder="Ingrese nuevo titulo" required>
                <div class="valid-feedback">
                  Looks good!
                </div>
              </div>
              <div class="col-md-4 mb-3">
                <label for="validationCustom03">Pais</label>
                <select id="inputState" name="owner" class="form-control">
                        @foreach ($paises as $value)
                            @foreach ($value as $pais)
                                <option>{{ $pais->Name }}</option>
                            @endforeach
                        @endforeach
                        {{-- {{ var_dump($data) }} --}}
                </select>
              </div>
            </div>
            <button class="btn btn-primary" type="submit" style="align-items:center">Actualizar</button>
          </form>

          <script>
          // Example starter JavaScript for disabling form submissions if there are invalid fields
          (function() {
            'use strict';
            window.addEventListener('load', function() {
              // Fetch all the forms we want to apply custom Bootstrap validation styles to
              var forms = document.getElementsByClassName('needs-validation');
              // Loop over them and prevent submission
              var validation = Array.prototype.filter.call(forms, function(form) {
                form.addEventListener('submit', function(event) {
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
