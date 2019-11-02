import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from "../store/ProjectsData";

class FetchData extends Component {
    componentWillMount() {
        // This method runs when the component is first added to the page
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    render() {
        return (
            <div>
                <h1>Projects</h1>
                <p></p>
                <p></p>
                {renderProjectsTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderProjectsTable(props) {
    return (
        <table className='table'>
            <thead>
                <tr>
                    <th>System Record Id</th>
                    <th>Project Id.</th>
                    <th>Project Name.</th>
                    <th>Customer</th>
                </tr>
            </thead>
            <tbody>
                {props.forecasts.map(item =>
                    <tr key={item.Id}>
                        <td>{item.Project.Id}</td>
                        <td>{item.Project.Name}</td>
                        <td>{item.Customer.Name}</td>
                       
                    </tr>
                )}
            </tbody>
        </table>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.weatherForecasts,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
