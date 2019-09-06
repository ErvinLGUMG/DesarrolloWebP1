@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Usuarios</a>
    </li>
@endsection

@section('thead')
    <th colspan="3" style="text-align:center">OPCIONES</th>
@endsection
@section('tbody')
    <tr>
        <td style="text-align:center"> <a class="btn btn-success" href="{{ route('editorials.create') }}" role="button">Crear Editorial</a> </td>
    </tr>
<th colspan="3" style="text-align:center">EDITORIALES</th>


    @foreach ($editorials as $item)
        @foreach ($item as $editorial)
            <tr>
              <td colspan="3" style="text-align:center">
                  <a href="{{ route('editorials.show',$editorial->EditorialId) }}"> {{ $editorial->Name }}</a>
                </td>
            </tr>
        @endforeach
    @endforeach

@endsection


