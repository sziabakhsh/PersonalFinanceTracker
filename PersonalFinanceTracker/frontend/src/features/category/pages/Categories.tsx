import {Container, Col, Row} from 'react-bootstrap'
import CategoryForm from "../components/CategoryForm"
import CategoryGrid from '../components/CategoryGrid'

export default function Categories() {


  return (
    <Container fluid>
            <Row className="mb-4">
        <Col>
          <h2>Categories</h2>
        </Col>
      </Row>

      <Row>

        <Col lg={4}>
          <CategoryForm />
        </Col>

        <Col lg={8}>
          <CategoryGrid />
        </Col>

      </Row>
    </Container>
  )
}
