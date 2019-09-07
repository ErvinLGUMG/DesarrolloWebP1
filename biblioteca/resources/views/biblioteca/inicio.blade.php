@extends('biblioteca.maqueta')

@section('seccion')

    <h1 class="display-2">{{$title}}</h1>
    <div class="row">

    @foreach ($listMenu as $item)
        @foreach ($item as $value)
        <div class="card d-inline" style="width: 18rem; margin:15px 40px ">
            <img src="{{ asset($value->ImagenPath) }}" width="150" height="250" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">{{$value->Title}}</h5>
            <p class="card-text">{{$value->Description}}</p>
            <a href="{{ asset($value->PdfPath) }}" target="_blank" class="btn btn-primary">Descargar </a>
            </div>
          </div>
        @endforeach
    @endforeach

    </div>

@endsection
