<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class AuthorController extends Controller
{
    public function __construct(){
        $this->middleware('admin');
    }

    public function create()
    {
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Country/ListCountry');
        $v1 = $request->getBody();

        $paises = json_decode($v1);

        return view('authors.create', ['paises'=>$paises]);
    }

    public function store()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('34.217.191.19/libraryapi/api/Author/Create', [
            'body'=>json_encode([
                'AuthorId' => request('id'),
                'Name' => request('name'),
                'CountryId' => request('pais'),
                'State' => request('state')
            ])
        ]);
        return $response->getBody();
        //return redirect()->route('users.index');
    }

    public function createEdit()
    {
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Country/ListCountry');
        $v3 = $request->getBody();
        $paises = json_decode($v3);

        return view('authors.edit',['paises'=>$paises]);
    }

    public function storeEdit()
    {
        $client = new Client();
        $request = $client->get('http://34.217.191.19/LibraryApi/api/Country/ListCountry');
        $v3 = $request->getBody();
        $v3 = json_decode($v3);
        $countId = '';
        foreach ($v3 as $value) {
            foreach ($value as $Country) {
                if ($Country->Name == request('country')) {
                    $countId = $Country->CountryId;
                    break;
                }
            }
        }

        $body = json_encode([
            'AuthorlId' => request('author'),
            'Name' => request('name'),
            'CountryId' =>$countId
        ]);

        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('34.217.191.19/libraryapi/api/Author/Update', [
            'body'=>$body
        ]);
        return $response->getBody();
        // return $body;
    }

    public function delete(){
        return view('authors.delete');
    }

    public function eliminar()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('34.217.191.19/LibraryApi/api/Security/ChangeStateUser?UserId='.request('id').'&State=false');

        return $response->getBody();
    }
}
