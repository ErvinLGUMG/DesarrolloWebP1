<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use GuzzleHttp\Client;
use GuzzleHttp\Exeption\GuzzleException;
use phpDocumentor\Reflection\DocBlock\Tags\Return_;

use function GuzzleHttp\json_decode;

class BibliotecaController extends Controller
{
    public function index(){

        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Category/ListCategory');
        $menu = $request->getBody();


        return view('welcome',['menu'=> json_decode($menu)]);

    }



    public function cursos($id,$name,$tipo){

        // menu
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Category/ListCategory');
        $menu = $request->getBody();


        // categiria por busqueda o todos
        unset($result);
        $list = New Client();
        if ( ($id!= 99) && ($tipo == 'CATEGORIA') ){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Category?CategoryId='.$id);
            }elseif($tipo=='CATEGORIA'){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
            }elseif( ($id!= 99) && ($tipo == 'AUTOR') ){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Author?AuthorId='.$id);
            }elseif($tipo=='AUTOR'){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
            }elseif( ($id!= 99) && ($tipo == 'EDITORIAL') ){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Editorial?EditorialId='.$id);
            }elseif($tipo=='EDITORIAL'){
            $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
        }

        $listMenu = $result->getBody();


        //return ['title'=>$id, 'menu' => json_decode($menu)];
        return view('biblioteca.inicio',
        [   'title'=>$name, 'menu' => json_decode($menu)
            ,'listMenu' => json_decode($listMenu)
        ]);
    }

    public function store(){

    // menu
    $client = new Client();
    if(request('tipo') == 'CATEGORIA' ){
    $result = $client->get('http://34.217.191.19/LibraryApi/api/Category/ListCategory');
    }elseif (request('tipo') == 'AUTOR'){
    $result = $client->get('http://34.217.191.19/LibraryApi/api/Author/ListAuthor');
    }elseif (request('tipo') == 'EDITORIAL'){
    $result = $client->get('http://34.217.191.19/LibraryApi/api/Editorial/ListEditorial');
    }
    $menu = $result->getBody();

    // categiria por busqueda o todos
    unset($result);
    $list = New Client();
    if ( (request('id')!= 99) && (request('tipo') == 'CATEGORIA') ){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Category?CategoryId='.request('id'));
    }elseif(request('tipo')=='CATEGORIA'){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
    }elseif( (request('id')!= 99) && (request('tipo') == 'AUTOR') ){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Author?AuthorId='.request('id'));
    }elseif(request('tipo')=='AUTOR'){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
    }elseif( (request('id')!= 99) && (request('tipo') == 'EDITORIAL') ){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/Editorial?EditorialId='.request('id'));
    }elseif(request('tipo')=='EDITORIAL'){
    $result = $list->get('http://34.217.191.19/LibraryApi/api/Document/ListDocument');
    }

    $listMenu = $result->getBody();

        //return ['title'=>request('tipo'), 'menu' => json_decode($menu),'listMenu' => json_decode($listMenu)];
        //return back()->with(['title'=>request('tipo'), 'menu' => json_decode($menu),'listMenu' => json_decode($listMenu)]);
        return view('biblioteca.inicio',
        [   'title'=>request('tipo'), 'menu' => json_decode($menu)
            ,'listMenu' => json_decode($listMenu)
        ]);
        //return $menu;
        //return request();

        }

    /*public function busqueda(){

        return view('biblioteca.inicio');

    }*/


}
