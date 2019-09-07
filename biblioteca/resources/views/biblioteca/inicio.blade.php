@extends('biblioteca.maqueta')

@section('seccion')

    <h1 class="display-2">{{$title}}</h1>
    <br>
<form method="POST" action="{{route('tipobusqueda')}}">
        @csrf
        <div class="form-group">
            <label for="exampleFormControlSelect1">Tipo Busqueda</label>
                <select name="tipo" class="form-control mb-8" id="exampleFormControlSelect1">
                    <option></option>
                    <option value="CATEGORIA">Categoria</option>
                    <option value="AUTOR">Autor</option>
                    <option value="EDITORIAL">Editorial</option>
                </select>
        </div>
        <button type="submit" class="btn btn-primary mb-2">Buscar</button>
        <input type="hidden" name="titulo" id="titulo" value="{{$title}}">
        <input type="hidden" name="id" id="id" value="99">
    </form>
    <br>
    <div class="row">
    @foreach ($listMenu as $item)
        @foreach ($item as $value)
        <div class="card d-inline" style="width: 18rem; margin:15px 40px ">
            <img src="{{ asset($value->ImagenPath) }}" width="150" height="250" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">{{$value->Title}}</h5>
            <p class="card-text" style="height: 400px">{{$value->Description}}</p>
            <a href="{{ asset($value->PdfPath) }}" target="_blank"  class="d-flex align-items-end  btn btn-primary">Descargar </a>
            </div>
          </div>
        @endforeach
    @endforeach

    </div>

@endsection
