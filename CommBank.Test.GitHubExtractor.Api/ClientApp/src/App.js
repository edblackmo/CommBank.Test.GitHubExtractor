import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { CommitsDataGrid } from './components/DataGrid';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />               
                <Route path='/fetch-data' exact component={FetchData} />
                <Route path='/fetch-data/commits' exact component={CommitsDataGrid} />
            </Layout>
        );
    }
}
