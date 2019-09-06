<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class BookController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        //
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        $categorias[] = array();
        $editoriales[] = array();
        $autores[] = array();

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Category/ListCategory');
        $v1 = $request->getBody();

        $categorias = json_decode($v1);

        $request = $client->get('http://40.117.209.118/LibraryApi/api/Editorial/ListEditorial');
        $v2 = $request->getBody();

        $editoriales = json_decode($v2);

        $request = $client->get('http://40.117.209.118/LibraryApi/api/Author/ListAuthor');
        $v3 = $request->getBody();

        $autores = json_decode($v3);

        return view('books.create', [
            'categorias' => $categorias,
            'autores' => $autores,
            'editoriales' => $editoriales
        ]);
    }

    public function createEdit()
    {
        $categorias[] = array();
        $editoriales[] = array();
        $autores[] = array();
        $users[] = array();

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Category/ListCategory');
        $v1 = $request->getBody();

        $categorias = json_decode($v1);

        $request = $client->get('http://40.117.209.118/LibraryApi/api/Editorial/ListEditorial');
        $v2 = $request->getBody();

        $editoriales = json_decode($v2);

        $request = $client->get('http://40.117.209.118/LibraryApi/api/Author/ListAuthor');
        $v3 = $request->getBody();

        $autores = json_decode($v3);

        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/ListUsers');
        $v4 = $request->getBody();

        $users = json_decode($v4);

        return view('books.edit', [
            'categorias' => $categorias,
            'autores' => $autores,
            'editoriales' => $editoriales,
            'users' => $users
        ]);
    }

    public function store($id)
    {
        $client = new Client([
            'headers' => ['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/libraryapi/api/Document/Create', [
            'body' => json_encode([
                'Title' => request('title'),
                'Description' => request('description'),
                'ImagenPath' => request('imagen'),
                'PdfPath' => request('pdf'),
                'CategoryId' => request('category'),
                'AuthorId' => request('author'),
                'EditorialId' => request('editorial'),
            ])
        ]);
        return $response->getBody();
        //return redirect()->route('users.index');
    }
    public function storeEdit()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Category/ListCategory');
        $v4 = $request->getBody();
        $v4 = json_decode($v4);
        $catId = '';

        foreach ($v4 as $value) {
            foreach ($value as $category) {
                if ($category->Name == request('cat')) {
                    $catId = $category->CategoryId;
                    break;
                }
            }
        }

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Author/ListAuthor');
        $v3 = $request->getBody();
        $v3 = json_decode($v3);
        $autId = '';
        foreach ($v3 as $value) {
            foreach ($value as $author) {
                if ($author->Name == request('aut')) {
                    $autId = $author->AuthorlId;
                    break;
                }
            }
        }

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Editorial/ListEditorial');
        $v2 = $request->getBody();
        $v2 = json_decode($v2);
        $editId = '';
        foreach ($v2 as $value) {
            foreach ($value as $editorial) {
                if ($editorial->Name == request('edit')) {
                    $editId = $editorial->EditorialId;
                }
            }
        }

        $body = json_encode([
            "DocumentId"=> request('iddoc'),
            "Title"=> request('title'),
            "Description"=>request('descrip'),
            "ImagenPath"=> request('imagen'),
            "PdfPath"=> request('pdf'),
            "Private"=> request('private'),
            "UserId"=> request('owner'),
            "CategoryId"=> $catId,
            "AuthorId"=> $autId,
            "EditorialId"=> $editId
        ]);

        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/libraryapi/api/Document/Update', [
            'body'=>$body
        ]);
        return $response->getBody();
        // return $body;
        //return [$catId, $editId, $autId];
        // return request();
        // return redirect()->route('users.index');
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit()
    {
        //return view('books.edit');
    }

    public function delete()
    {
        return view('books.delete');
    }

    public function eliminar()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/LibraryApi/api/Document/ChangeState?DocumentId='.request('id').'&State=false');

        return $response->getBody();
        // return request('id');
    }
}
