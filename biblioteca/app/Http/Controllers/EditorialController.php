<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class EditorialController extends Controller
{
    public function index()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Editorial/ListEditorial');
        $editorials = $request->getBody();

        return view('editorials.index',['editorials' => json_decode($editorials)]);
    }

    public function create()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Country/ListCountry');
        $v1 = $request->getBody();

        $paises = json_decode($v1);


        return view('editorials.create',['paises'=>$paises]);
    }

    public function store()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/libraryapi/api/Editorial/Create', [
            'body'=>json_encode([
                 'Name' => request('name'),
                'CountryId' => request('pais'),
                 'State' => 1
            ])
        ]);
        return $response->getBody();

        // dd('LLEGO A STORE');
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Editorial/Editorial?EditorialId='.$id);
        $editorials = $request->getBody()->getContents();

        $editorials = json_decode($editorials);
        foreach ($editorials as $value) {
            foreach ($value as  $editorial) {
                $data = $editorial;
            }
        }
        $editorial = $data;
        return view('editorials.show', compact('editorial'));
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        return view('editorials.edit',['id'=>$id]);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update($id)
    {
        $body = json_encode([
            'EditorialId' => $id,
            'Name' => request('name'),
        ]);

        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/libraryapi/api/Editorial/Update', [
            'body'=>$body
        ]);
        return $response->getBody();
    }

    public function delete($id)
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
        ]);
        $response = $client->post('40.117.209.118/LibraryApi/api/Editorial/ChangeState?EditorialId='.$id.'&State=false');
        return redirect()->route('editorials.index');
    }
}
