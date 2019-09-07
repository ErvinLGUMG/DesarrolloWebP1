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
    <td style="text-align:center"> <a class="btn btn-primary" href="{{ route('books.edit') }}" role="button">Actualizar un libro</a> </td>
    <td style="text-align:center"> <a class="btn btn-danger" href="{{ route('books.delete') }}" role="button">Eliminar un libro</a> </td>
</tr>
<th colspan="3" style="text-align:center">ACTUALIZAR LIBRO</th>
<tr>
    <td colspan="2">

        <form method="POST" action="{{ route('books.store',$id) }}" class="needs-validation" novalidate>
            @csrf
            <div class="form-row">
                    <div class="col-md-6 mb-3">
                        <label for="validationCustom03">Titulo</label>
                        <input type="text" name="imagen" class="form-control" id="validationCustom04"
                            placeholder="" required>
                        <div class="invalid-feedback">
                            Please provide a valid city.
                        </div>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="validationCustom04">Descripcion</label>
                        <input type="text" name="pdf" class="form-control" id="validationCustom04"
                            placeholder="" required>
                        <div class="invalid-feedback">
                            Please provide a valid city.
                        </div>
                    </div>
                </div>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputState">Categoria</label>
                    <select id="inputState" name="cat" class="form-control">
                        @foreach ($categorias as $value)
                            @foreach ($value as $categoria)
                                <option>{{ $categoria->Name }}</option>
                        @endforeach
                        @endforeach
                        {{-- {{ var_dump($data) }} --}}
                    </select>
                </div>
                <div class="col-md-4 mb-3">
                    <label for="validationCustom05">Autor</label>
                    <select id="inputState" name="aut" class="form-control">
                        @foreach ($autores as $value)
                            @foreach ($value as $autor)
                                <option>{{ $autor->Name }}</option>
                        @endforeach
                        @endforeach
                        {{-- {{ var_dump($data) }} --}}
                    </select>
                </div>
                <div class="col-md-4 mb-3">
                    <label for="validationCustom06">Editorial</label>
                    <select id="inputState" name="edit" class="form-control">
                        @foreach ($editoriales as $value)
                            @foreach ($value as $editorial)
                                <option>{{ $editorial->Name }}</option>
                        @endforeach
                        @endforeach
                        {{-- {{ var_dump($data) }} --}}
                    </select>
                </div>
            </div>
            <div class="form-row">
                <div class="col-md-6 mb-3">
                    <label for="validationCustom03">Imagen Path</label>
                    <input type="text" name="imagen" class="form-control" id="validationCustom04"
                        placeholder="C://user/documents/..." required>
                    <div class="invalid-feedback">
                        Please provide a valid city.
                    </div>
                </div>
                <div class="col-md-6 mb-3">
                    <label for="validationCustom04">PDF Path</label>
                    <input type="text" name="pdf" class="form-control" id="validationCustom04"
                        placeholder="C://user/documents/..." required>
                    <div class="invalid-feedback">
                        Please provide a valid city.
                    </div>
                </div>
            </div>
            <label for=""> Privar documento? </label><br>
            <div class="btn-group btn-group-toggle" data-toggle="buttons">

                <label class="btn btn-primary ">
                    <input type="radio" name="private" id="option2" autocomplete="off" value=1> SI
                </label>
                <label class="btn btn-secondary ">
                    <input type="radio" name="private" id="option3" autocomplete="off" value=0> NO
                </label>
            </div><br><br>
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
