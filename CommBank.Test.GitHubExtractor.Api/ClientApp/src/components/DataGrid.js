import React from 'react';

function CommitsDataGrid(props) {

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>SHA</th>
                    <th>Commit Message</th>
                    <th>Commit Author Name</th>
                    <th>Commit Author Email</th>
                </tr>
            </thead>
            <tbody>
                {props.commits.map(commit =>
                    <tr key={commit.sha}>
                        <td>{commit.message}</td>
                        <td>{commit.author.name}</td>
                        <td>{commit.author.email}</td>                        
                    </tr>
                )}
            </tbody>
        </table>
    );
}